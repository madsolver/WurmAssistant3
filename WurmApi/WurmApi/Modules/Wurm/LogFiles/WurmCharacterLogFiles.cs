using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using AldursLab.Essentials;
using AldurSoft.WurmApi.Infrastructure;
using AldurSoft.WurmApi.Modules.Events;
using AldurSoft.WurmApi.Modules.Events.Internal;
using AldurSoft.WurmApi.Modules.Events.Internal.Messages;
using AldurSoft.WurmApi.Modules.Events.Public;
using AldurSoft.WurmApi.Utility;
using JetBrains.Annotations;

namespace AldurSoft.WurmApi.Modules.Wurm.LogFiles
{
    public class WurmCharacterLogFiles : IWurmCharacterLogFiles, IDisposable
    {
        readonly ILogger logger;
        readonly LogFileInfoFactory logFileInfoFactory;

        IReadOnlyDictionary<LogType, LogTypeManager> wurmLogTypeToLogTypeManagerMap =
            new Dictionary<LogType, LogTypeManager>();

        readonly ThreadSafeProperty<DateTime> oldestLogFileDate = ThreadSafeProperty.Create(Time.Get.LocalNow);

        readonly HashSet<string> blacklistedFileNames = new HashSet<string>();

        volatile int rebuildRequired = 1;
        readonly object locker = new object();
        readonly FileSystemWatcher directoryWatcher;

        readonly InternalEvent onFilesAddedOrRemoved;

        internal WurmCharacterLogFiles(
            [NotNull] CharacterName characterName,
            [NotNull] string fullDirPathToCharacterLogsDir,
            [NotNull] ILogger logger,
            [NotNull] LogFileInfoFactory logFileInfoFactory, 
            [NotNull] IInternalEventInvoker internalEventInvoker)
        {
            if (characterName == null) throw new ArgumentNullException("characterName");
            if (fullDirPathToCharacterLogsDir == null) throw new ArgumentNullException("fullDirPathToCharacterLogsDir");
            if (logger == null) throw new ArgumentNullException("logger");
            if (logFileInfoFactory == null) throw new ArgumentNullException("logFileInfoFactory");
            if (internalEventInvoker == null) throw new ArgumentNullException("internalEventInvoker");
            this.logger = logger;
            this.logFileInfoFactory = logFileInfoFactory;
            CharacterName = characterName;
            FullDirPathToCharacterLogsDir = fullDirPathToCharacterLogsDir;

            onFilesAddedOrRemoved = internalEventInvoker.Create(() => new CharacterLogFilesAddedOrRemoved(CharacterName));

            directoryWatcher = new FileSystemWatcher(fullDirPathToCharacterLogsDir)
            {
                Filter = "*.txt",
                NotifyFilter = NotifyFilters.FileName
            };
            directoryWatcher.Created += DirectoryWatcherOnChanged;
            directoryWatcher.Deleted += DirectoryWatcherOnChanged;
            directoryWatcher.Renamed += DirectoryWatcherOnChanged;

            directoryWatcher.EnableRaisingEvents = true;
        }

        public CharacterName CharacterName { get; private set; }
        public string FullDirPathToCharacterLogsDir { get; private set; }
        public DateTime OldestLogFileDate { get { return oldestLogFileDate.Value; }}

        void DirectoryWatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            rebuildRequired = 1;
            onFilesAddedOrRemoved.Trigger();
        }

        public IEnumerable<LogFileInfo> GetLogFiles(DateTime dateFrom, DateTime dateTo)
        {
            Refresh();
            List<LogFileInfo> files = new List<LogFileInfo>();
            foreach (var typeManager in wurmLogTypeToLogTypeManagerMap.Values)
            {
                files.AddRange(typeManager.GetLogFileInfos(dateFrom, dateTo));
            }
            return files.OrderBy(info => info.LogFileDate.DateTime).ToList();
        }

        public IEnumerable<LogFileInfo> GetLogFiles(DateTime dateFrom, DateTime dateTo, LogType logType)
        {
            Refresh();
            LogTypeManager logTypeManager;
            if (wurmLogTypeToLogTypeManagerMap.TryGetValue(logType, out logTypeManager))
            {
                var files = logTypeManager.GetLogFileInfos(dateFrom, dateTo);
                return files;
            }
            else
            {
                return new LogFileInfo[0];
            }
        }

        public IEnumerable<LogFileInfo> TryGetLogFilesForSpecificPm(DateTime dateFrom, DateTime dateTo, CharacterName pmCharacterName)
        {
            Refresh();
            var allPmLogs = GetLogFiles(dateFrom, dateTo, LogType.Pm);
            return
                allPmLogs.Where(
                    info => info.FileName.IndexOf(pmCharacterName.Normalized, StringComparison.InvariantCultureIgnoreCase) > -1);
        }

        private void Refresh()
        {
            if (rebuildRequired == 1)
            {
                lock (locker)
                {
                    if (Interlocked.CompareExchange(ref rebuildRequired, 0, 1) == 1)
                    {
                        List<LogFileInfo> parsedFiles = ObtainLatestFiles();
                        if (parsedFiles.Any())
                        {
                            oldestLogFileDate.Value = parsedFiles.Min(info => info.LogFileDate.DateTime);
                        }
                        UpdateTypeManagers(parsedFiles);
                    }
                }
            }

        }

        private void UpdateTypeManagers(List<LogFileInfo> parsedFiles)
        {
            var groupedFiles = parsedFiles.GroupBy(info => info.LogType);

            var newMap = new Dictionary<LogType, LogTypeManager>();

            foreach (var group in groupedFiles)
            {
                var logType = group.Key;
                var logFileInfos = group.AsEnumerable();
                LogTypeManager typeManager;

                if (!wurmLogTypeToLogTypeManagerMap.TryGetValue(logType, out typeManager))
                {
                    typeManager = new LogTypeManager();
                    typeManager.Rebuild(logFileInfos);
                }
                else
                {
                    typeManager.Rebuild(logFileInfos);
                }
                
                newMap.Add(logType, typeManager);
            }

            wurmLogTypeToLogTypeManagerMap = newMap;
        }

        private List<LogFileInfo> ObtainLatestFiles()
        {
            var parsedFiles = new List<LogFileInfo>();

            var dir = new DirectoryInfo(FullDirPathToCharacterLogsDir);
            var allFiles = dir.GetFiles();

            foreach (var fileInfo in allFiles)
            {
                if (blacklistedFileNames.Contains(fileInfo.Name))
                {
                    continue;
                }
                var logFileInfo = logFileInfoFactory.Create(fileInfo);
                if (!logFileInfo.ParsingError)
                {
                    parsedFiles.Add(logFileInfo);
                }
                else
                {
                    blacklistedFileNames.Add(fileInfo.Name);
                    GenerateLogMessageForFile(fileInfo);
                }
            }

            return parsedFiles;
        }

        private void GenerateLogMessageForFile(FileInfo fileInfo)
        {
            if (fileInfo.Name.StartsWith("irc.rizon.net"))
            {
                logger.Log(
                    LogLevel.Info,
                    "Skipping log file, that appears to be log from IRC (unsupported), file name: " + fileInfo.FullName,
                    this,
                    null);
            }

            else if (fileInfo.Name.StartsWith("test."))
            {
                logger.Log(
                    LogLevel.Info,
                    "Skipping log file, that appears to be from test server (unsupported), file name: "
                    + fileInfo.FullName,
                    this,
                    null);
            }
            else
            {
                logger.Log(
                    LogLevel.Warn,
                    "Skipping file that had parsing errors, file name: " + fileInfo.FullName,
                    this,
                    null);
            }
        }

        public void Dispose()
        {
            directoryWatcher.EnableRaisingEvents = false;
            directoryWatcher.Dispose();
        }
    }
}