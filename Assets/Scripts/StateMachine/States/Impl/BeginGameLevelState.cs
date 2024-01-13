using System.Collections.Generic;
using Helpers;
using Mirror;
using Models;
using NetworkMessages;
using Palmmedia.ReportGenerator.Core.Common;
using Services.GameRoles;
using Services.Network;
using Services.PlayerRepository;
using Signals;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace StateMachine.States.Impl
{
    public class BeginGameLevelState : StateBase
    {
        private readonly IGameRoleService _gameRoleService;
        private readonly SignalBus _signalBus;
        private readonly IPlayerRepository _playerRepository;
        private readonly INetworkServerManager _networkServerManager;
        private UniTaskCompletionSource _roleAttachTcs;

        public BeginGameLevelState(
            IGameRoleService gameRoleService, 
            SignalBus signalBus,
            IPlayerRepository playerRepository,
            INetworkServerManager networkServerManager
        )
        {
            _gameRoleService = gameRoleService;
            _signalBus = signalBus;
            _playerRepository = playerRepository;
            _networkServerManager = networkServerManager;
        }

        protected override async UniTask OnEnter()
        {
            _roleAttachTcs?.TrySetCanceled();
            
            _gameRoleService.InitializeRoles(1);
            
            _networkServerManager.RegisterMessageHandler<PlayerReadyMessage>(OnPlayerReady);

           // var roles = new List<GameRole>();
            
            foreach (var kvp in _playerRepository.Players)
            {
                _gameRoleService.TryGetGameRole(out var role);
                
                // roles.Add(new GameRole
                // {
                //     Role = (byte)role,
                //     ClientId = kvp.Value.ConnectionId
                // });
            }
            
            foreach (var kvp in _playerRepository.Players)
            {
                var player = kvp.Value;
                
                _gameRoleService.TryGetGameRole(out var role);

                player.Role = role;
                
                _networkServerManager.SendTo(player.ConnectionId, new RoleInitialAssignMessage
                {
                    Role = (byte)role,
                });
            }
            
            _roleAttachTcs = new UniTaskCompletionSource();

            await _roleAttachTcs.Task;
            
            _signalBus.Fire<SignalLevelStart>();
            
            StateMachine.ChangeState<GameLevelLoopState>();
        }

        protected override UniTask OnExit()
        {
            _networkServerManager.UnRegisterMessageHandler<PlayerReadyMessage>();

            return UniTask.CompletedTask;
        }

        private void OnPlayerReady(
            NetworkConnectionToClient conn, 
            PlayerReadyMessage msg, 
            int id)
        {
            var hasPlayer = _playerRepository.TryGet(conn.connectionId, out var player);
            
            if (!hasPlayer) return;

            player.Ready = true;

            foreach (var kvp in _playerRepository.Players)
            {
                if (!kvp.Value.Ready)
                    return;
            }

            _roleAttachTcs.TrySetResult();
        }
    }
}