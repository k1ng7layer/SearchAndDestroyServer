using System;
using NetworkMessages;
using Services.Network;
using Services.SceneLoading;
using Services.ServerManager;
using StateMachine;
using StateMachine.States.Impl;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Utils
{
    public class ControlPanel : MonoBehaviour
    {
        [SerializeField] private Button RestartButton;
        [Inject] private readonly ServerStateMachine _serverStateMachine;

        private void Awake()
        {
            RestartButton.OnClickAsObservable().Subscribe(_ =>
            {
                _serverStateMachine.ChangeState<NextLevelLoadingState>();
            }).AddTo(gameObject);
        }
    }
}