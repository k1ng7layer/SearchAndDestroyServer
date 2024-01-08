using System;
using Models;
using UnityEngine;

namespace Services.PlayerInput
{
    public interface IPlayerInputService
    {
        event Action<Player, float> InputRotation;
        event Action<Player, Vector3> InputDirection;
    }
}