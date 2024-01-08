using System;
using JCMG.EntitasRedux;
using Mirror;
using Signals;
using UnityEngine;
using Utils;
using Zenject;

namespace Ecs.Game.Systems
{
    public class StopGameRoundSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly GameContext _game;
        private readonly SignalBus _signalBus;

        public StopGameRoundSystem(
            GameContext game,
            SignalBus signalBus)
        {
            _game = game;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<SignalLevelStop>(OnGameStopped);
        }
        
        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalLevelStop>(OnGameStopped);
        }

        private void OnGameStopped()
        {
            Debug.Log($"TEST OnGameStopped");
            
            _game.ReplaceGameState(EGameState.Default);
        }
    }
}