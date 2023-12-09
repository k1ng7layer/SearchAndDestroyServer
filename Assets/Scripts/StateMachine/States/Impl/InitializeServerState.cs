using HttpTransfer;
using Palmmedia.ReportGenerator.Core.Common;
using Services.ClientStateHandler;
using Services.Network;
using Services.SceneLoading;
using UniRx.Async;
using UnityEngine;

namespace StateMachine.States.Impl
{
    public class InitializeServerState : StateBase
    {
        private readonly INetworkServerManager _networkServerManager;
        private readonly IHttpClientService _httpClientService;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly IClientInitializationService _clientInitializationService;

        public InitializeServerState(
            INetworkServerManager networkServerManager, 
            IHttpClientService httpClientService,
            ISceneLoadingManager sceneLoadingManager,
            IClientInitializationService clientInitializationService
        )
        {
            _networkServerManager = networkServerManager;
            _httpClientService = httpClientService;
            _sceneLoadingManager = sceneLoadingManager;
            _clientInitializationService = clientInitializationService;
        }
        
        protected override async void OnEnter()
        {
            _networkServerManager.StartSever();

            var json = JsonSerializer.ToJsonString(new
            {
                Level = ELevelName.CLASSIC
            });
            //     
            // var responseMessage = await _httpClientService.PostAsync("mms", json);
            //
            // if (responseMessage.IsSuccessStatusCode)
            //     return;

            //var clientProcess = _clientInitializationService.ProcessClientsAsync();
            var loadingProcess = _sceneLoadingManager.LoadGameLevelAsync(ELevelName.CLASSIC);

            //await UniTask.WhenAll(clientProcess, loadingProcess);
            
            Debug.Log($"OnEnter finished");
        }
        
    }
}