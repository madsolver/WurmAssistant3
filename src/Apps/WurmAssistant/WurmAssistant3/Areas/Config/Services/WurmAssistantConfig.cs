using System;
using System.Windows.Forms;
using AldursLab.Essentials.Extensions.DotNet;
using AldursLab.PersistentObjects;
using AldursLab.WurmApi;
using AldursLab.WurmAssistant3.Areas.Config.Contracts;
using AldursLab.WurmAssistant3.Areas.Core.Contracts;
using AldursLab.WurmAssistant3.Areas.WurmApi.Parts;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace AldursLab.WurmAssistant3.Areas.Config.Services
{
    [KernelBind(BindingHint.Singleton), PersistentObject("WurmAssistantConfig")]
    public class WurmAssistantConfig : PersistentObjectBase, IWurmAssistantConfig
    {
        readonly IConsoleArgs consoleArgs;

        [JsonProperty]
        int version = 0;

        [JsonProperty]
        string wurmGameClientInstallDirectory;

        [JsonProperty, Obsolete("Back to supporting windows only")]
        Platform runningPlatform;

        [JsonProperty("reSetupRequested")]
        bool wurmApiResetRequested;

        [JsonProperty]
        bool dropAllWurmApiCachesToggle;

        public WurmAssistantConfig([NotNull] IConsoleArgs consoleArgs)
        {
            if (consoleArgs == null) throw new ArgumentNullException(nameof(consoleArgs));
            this.consoleArgs = consoleArgs;
        }

        protected override void OnPersistentDataLoaded()
        {
            if (version == 0)
            {
                dropAllWurmApiCachesToggle = true;
                version = 1;
            }

            if (this.WurmApiResetRequested || WurmGameClientInstallDirectory.IsNullOrEmpty())
            {
                // run setup;
                var view = new WurmApiSetupForm(WurmGameClientInstallDirectory, WurmUnlimitedMode);
                if (view.ShowDialog() != DialogResult.OK)
                {
                    throw new ConfigCancelledException("Configuration dialog was cancelled by user");
                }

                if (WurmGameClientInstallDirectory != view.SelectedWurmInstallDirectory)
                {
                    WurmGameClientInstallDirectory = view.SelectedWurmInstallDirectory;
                    DropAllWurmApiCachesToggle = true;
                }

                WurmApiResetRequested = false;
            }
        }

        public bool WurmUnlimitedMode => consoleArgs.WurmUnlimitedMode;

        public string WurmGameClientInstallDirectory
        {
            get { return wurmGameClientInstallDirectory; }
            set
            {
                if (value == wurmGameClientInstallDirectory)
                    return;
                wurmGameClientInstallDirectory = value;
                FlagAsChanged();
            }
        }

        public bool WurmApiResetRequested
        {
            get { return wurmApiResetRequested; }
            set
            {
                if (value == wurmApiResetRequested)
                    return;
                wurmApiResetRequested = value;
                FlagAsChanged();
            }
        }

        public bool DropAllWurmApiCachesToggle
        {
            get { return dropAllWurmApiCachesToggle; }
            set
            {
                if (value == dropAllWurmApiCachesToggle)
                    return;
                dropAllWurmApiCachesToggle = value;
                FlagAsChanged();
            }
        }
    }
}