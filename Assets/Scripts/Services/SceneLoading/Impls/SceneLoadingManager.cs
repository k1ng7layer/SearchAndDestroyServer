using System;
using Core.LoadingProcessor.Impls;
using Game.Services.LoadingProcessor.Impls;
using JCMG.EntitasRedux;
using Services.LoadingProcessor.Impls;
using UniRx.Async;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.SceneLoading.Impls
{
    public class SceneLoadingManager : ISceneLoadingManager, ITickable
    {
        private readonly SignalBus _signalBus;
        private Core.LoadingProcessor.Impls.LoadingProcessor _processor;
        private ELevelName _currentLevel;
        private UniTaskCompletionSource _completionSource;
        private bool _loading;

        public SceneLoadingManager(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public event Action Loaded;

        public void LoadGameLevel(ELevelName levelName)
        {
            _loading = true;
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            
            if (_currentLevel != ELevelName.INITIALIZATION)
            {
                // var lastScene = SceneManager.GetSceneByName(_currentLevel.ToString());
                // if(lastScene.IsValid() && lastScene.isLoaded)
                //     _processor.AddProcess(new UnloadProcess(_currentLevel));
                
                var commonScene = SceneManager.GetSceneByName(ELevelName.COMMON.ToString());
                if(commonScene.IsValid() && commonScene.isLoaded)
                    _processor.AddProcess(new UnloadProcess(ELevelName.COMMON))
                        .AddProcess(new WaitUpdateProcess(10));
            }

            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.COMMON, LoadSceneMode.Additive));
                
            if (!string.IsNullOrWhiteSpace(_currentLevel.ToString()))
            {
                
                var lastScene = SceneManager.GetSceneByName(_currentLevel.ToString());
                if(lastScene.IsValid() && lastScene.isLoaded)
                    _processor.AddProcess(new UnloadProcess(_currentLevel));
            }
            
            _processor.AddProcess(new LoadingProcess(levelName, LoadSceneMode.Additive))
                //.AddProcess(new SetActiveSceneProcess(ELevelName.GAME))
                .AddProcess(new SetActiveSceneProcess(levelName));
                //.AddProcess(new UnloadProcess(ELevelName.INITIALIZATION));
            
            
            _processor.AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();

            Debug.Log($"_processor: {_processor.Progress}");
            _currentLevel = levelName;
        }

        public async UniTask LoadGameLevelAsync(ELevelName levelName)
        {
            _completionSource = new UniTaskCompletionSource();
            
            _processor = new Core.LoadingProcessor.Impls.LoadingProcessor();
            
            if (_currentLevel != ELevelName.INITIALIZATION)
            {
                // var lastScene = SceneManager.GetSceneByName(_currentLevel.ToString());
                // if(lastScene.IsValid() && lastScene.isLoaded)
                //     _processor.AddProcess(new UnloadProcess(_currentLevel));
                
                var commonScene = SceneManager.GetSceneByName(ELevelName.COMMON.ToString());
                if(commonScene.IsValid() && commonScene.isLoaded)
                    _processor.AddProcess(new UnloadProcess(ELevelName.COMMON))
                        .AddProcess(new WaitUpdateProcess(10));
            }

            _processor
                .AddProcess(new OpenLoadingWindowProcess(_signalBus))
                .AddProcess(new LoadingProcess(ELevelName.COMMON, LoadSceneMode.Additive));
                
            if (!string.IsNullOrWhiteSpace(_currentLevel.ToString()))
            {
                
                var lastScene = SceneManager.GetSceneByName(_currentLevel.ToString());
                if(lastScene.IsValid() && lastScene.isLoaded)
                    _processor.AddProcess(new UnloadProcess(_currentLevel));
            }
            
            _processor.AddProcess(new LoadingProcess(levelName, LoadSceneMode.Additive))
                //.AddProcess(new SetActiveSceneProcess(ELevelName.GAME))
                .AddProcess(new SetActiveSceneProcess(levelName));
            //.AddProcess(new UnloadProcess(ELevelName.INITIALIZATION));
            
            
            _processor.AddProcess(new RunContextProcess("GameContext"))
                .AddProcess(new WaitUpdateProcess(4))
                .AddProcess(new ProjectWindowBack(_signalBus))
                .DoProcess();

            Debug.Log($"_processor: {_processor.Progress}");
            _currentLevel = levelName;
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

        public void Tick()
        {
            if (_processor == null || !_loading)
                return;

            if (_processor.Progress >= 1)
            {
                Loaded?.Invoke();
                _loading = false;
            }
        }
    }
}