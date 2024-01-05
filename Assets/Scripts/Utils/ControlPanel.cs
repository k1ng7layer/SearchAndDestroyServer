using System;
using NetworkMessages;
using Services.Network;
using Services.SceneLoading;
using Services.ServerManager;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Utils
{
    public class ControlPanel : MonoBehaviour
    {
        [SerializeField] private Button RestartButton;
        [Inject] private INetworkServerManager _networkServerManager;
        [Inject] private IServerStateManager _serverStateManager;

        private void Awake()
        {
            RestartButton.OnClickAsObservable().Subscribe(_ =>
            {
                // _networkServerManager.SendToAll(new LevelLoadingMessage
                // {
                //     LevelName = ELevelName.CLASSIC.ToString()
                // });
                
                _serverStateManager.ChangeLevel(ELevelName.CLASSIC);
            }).AddTo(gameObject);
        }
    }
}