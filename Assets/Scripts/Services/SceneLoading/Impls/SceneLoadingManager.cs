using System;
using Core.LoadingProcessor.Impls;
using Game.Services.LoadingProcessor.Impls;
using Services.LoadingProcessor.Impls;
using UniRx.Async;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.SceneLoading.Impls
{
    public class SceneLoadingManager : ISceneLoadingManager
    {
        private readonly SignalBus _signalBus;
        private Core.LoadingProcessor.Impls.LoadingProcessor _processor;
        private ELevelName _currentLevel;

        public SceneLoadingManager(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void LoadGameLevel(ELevelName levelName)
        {
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.COMMON, LoadSceneMode.Additive))
                .AddProcess(new LoadingProcess(levelName, LoadSceneMode.Additive))
                //.AddProcess(new SetActiveSceneProcess(ELevelName.GAME))
                .AddProcess(new SetActiveSceneProcess(levelName));
                //.AddProcess(new UnloadProcess(ELevelName.INITIALIZATION));
                
            if (!string.IsNullOrWhiteSpace(_currentLevel.ToString()))
            {
                var lastScene = SceneManager.GetSceneByName(_currentLevel.ToString());
                if(lastScene.IsValid() && lastScene.isLoaded)
                    _processor.AddProcess(new UnloadProcess(_currentLevel));
            }
            
            _processor.AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();

            _currentLevel = levelName;
        }

        public async UniTask LoadGameLevelAsync(ELevelName levelName)
        {
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.COMMON, LoadSceneMode.Additive))
                .AddProcess(new LoadingProcess(levelName, LoadSceneMode.Additive))
                //.AddProcess(new SetActiveSceneProcess(ELevelName.GAME))
                .AddProcess(new SetActiveSceneProcess(levelName));
            //.AddProcess(new UnloadProcess(ELevelName.INITIALIZATION));
                
            if (!string.IsNullOrWhiteSpace(_currentLevel.ToString()))
            {
                var lastScene = SceneManager.GetSceneByName(_currentLevel.ToString());
                if(lastScene.IsValid() && lastScene.isLoaded)
                    _processor.AddProcess(new UnloadProcess(_currentLevel));
            }

            _processor.AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus));;

            _currentLevel = levelName;
            
            await UniTask.Run(async () =>
            {
                await UniTask.Delay(5000);
                Debug.Log($"ssssss");
            });
            
            await UniTask.Run(_processor.DoProcess, false);
        }

        public void LoadGameFromMenu()
        {
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.INITIALIZATION, LoadSceneMode.Additive))
                .AddProcess(new SetActiveSceneProcess(ELevelName.INITIALIZATION))
                .AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();
        }

        public void LoadGameFromSplash()
        {
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.INITIALIZATION, LoadSceneMode.Additive))
                .AddProcess(new SetActiveSceneProcess(ELevelName.INITIALIZATION))
                .AddProcess(new UnloadProcess(ELevelName.SPLASH))
                .AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();
            
            _currentLevel = ELevelName.INITIALIZATION;
        }

        public float GetProgress()
        {
            return _processor.Progress;
        }
    }
}