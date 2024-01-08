using System;
using JCMG.EntitasRedux;
using Services.LevelObjectProvider;
using Services.PlayerRepository;
using Signals;
using Utils;
using Zenject;

namespace Ecs.Game.Systems
{
    public class InitializeGameLevelSystem : IInitializeSystem, IDisposable
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly ILevelObjectsHolder _levelObjectsHolder;
        private readonly IPlayerRepository _playerRepository;
        private readonly SignalBus _signalBus;

        public InitializeGameLevelSystem(
            ActionContext action,
            GameContext game,
            ILevelObjectsHolder levelObjectsHolder,
            IPlayerRepository playerRepository,
            SignalBus signalBus)
        {
            _action = action;
            _game = game;
            _levelObjectsHolder = levelObjectsHolder;
            _playerRepository = playerRepository;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<SignalLevelStart>(OnLevelStart);
        }
        
        public void Dispose()
        {
            _signalBus.Unsubscribe<SignalLevelStart>(OnLevelStart);
        }

        private void OnLevelStart()
        {
            var objectsHolder = _levelObjectsHolder.CommonObjectsHolder;

            foreach (var spawnTransform in objectsHolder.NpcSpawnTransforms)
            {
                _action.CreateEntity().AddSpawnNpc(spawnTransform.position, spawnTransform.rotation);
            }
            
            foreach (var playerKvp in _playerRepository.Players)
            {
                _action.CreateEntity().AddSpawnPlayer(playerKvp.Value.ConnectionId);
            }
            
            _game.ReplaceGameState(EGameState.Countdown);
        }
    }
}