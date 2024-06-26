﻿using UniRx.Async;

namespace Core.LoadingProcessor
{
    public interface IProcessor
    {
        IProcessor AddProcess(IProcess process);
        void DoProcess();
        UniTask DoProcessAsync();
    }
}