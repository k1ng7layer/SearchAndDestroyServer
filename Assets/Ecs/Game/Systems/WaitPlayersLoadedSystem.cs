using JCMG.EntitasRedux;
using Models;
using Services.PlayerRepository;
using Services.PlayerService;

namespace Ecs.Game.Systems
{
    public class WaitPlayersLoadedSystem : IInitializeSystem
    {
        private readonly IPlayerStatusService _playerStatusService;
        private readonly IPlayerRepository _playerRepository;
        private readonly ActionContext _action;

        public WaitPlayersLoadedSystem(
            IPlayerStatusService playerStatusService, 
            IPlayerRepository playerRepository,
            ActionContext action
        )
        {
            _playerStatusService = playerStatusService;
            _playerRepository = playerRepository;
            _action = action;
        }
        
        public void Initialize()
        {
            //TODO: start timer
            _playerStatusService.PlayerLoaded += OnPlayerLoaded;
        }

        private void OnPlayerLoaded(Player _)
        {
            if (!AllLoaded()) return;
            
            foreach (var playerKvp in _playerRepository.Players)
            {
                _action.CreateEntity().AddSpawnPlayer(playerKvp.Value.ConnectionId);
            }
        }

        private bool AllLoaded()
        {
            // foreach (var playerKvp in _playerRepository.Players)
            // {
            //     if (!playerKvp.Value.Loaded)
            //         return false;
            // }

            // return true;

            return _playerRepository.Players.Count == 1;
        }
    }
}