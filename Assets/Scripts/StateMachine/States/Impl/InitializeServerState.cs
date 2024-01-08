using Palmmedia.ReportGenerator.Core.Common;
using Services.Network;
using Services.SceneLoading;
using Services.ServerManager.Impl;
using UniRx.Async;
using UnityEngine;

namespace StateMachine.States.Impl
{
    public class InitializeServerState : StateBase
    {
        private readonly INetworkServerManager _networkServerManager;
        private readonly ISceneLoadingManager _sceneLoadingManager;

        public InitializeServerState(
            INetworkServerManager networkServerManager,
            ISceneLoadingManager sceneLoadingManager
        )
        {
            _networkServerManager = networkServerManager;
            _sceneLoadingManager = sceneLoadingManager;
        }
        
        protected override async UniTask OnEnter()
        {
            _networkServerManager.StartSever();
            
            await _sceneLoadingManager.LoadGameLevelAsync(ELevelName.CLASSIC);
            
            StateMachine.ChangeState<PendingForConnectionsState>();
        }
    }
}