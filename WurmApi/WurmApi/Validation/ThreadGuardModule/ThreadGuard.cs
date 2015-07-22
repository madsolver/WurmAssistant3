﻿using System.Threading;

namespace AldurSoft.WurmApi.Validation.ThreadGuardModule
{
    public class ThreadGuard : IThreadGuard
    {
        private readonly int threadId;

        public ThreadGuard()
        {
            this.threadId = Thread.CurrentThread.ManagedThreadId;
        }

        public void ValidateCurrentThread()
        {
            if (Thread.CurrentThread.ManagedThreadId != threadId)
            {
                throw new ThreadGuardException(
                    string.Format(
                        "Method was called on different threadId {0}, expected invocation on threadId {1}",
                        Thread.CurrentThread.ManagedThreadId,
                        threadId));
            }
        }
    }

    public class ThreadGuardStub : IThreadGuard
    {
        public void ValidateCurrentThread()
        {
        }
    }
}