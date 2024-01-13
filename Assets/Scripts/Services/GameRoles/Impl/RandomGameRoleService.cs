using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services.GameRoles.Impl
{
    public class RandomGameRoleService : IGameRoleService
    {
        private readonly Queue<EGameRole> _roles = new();
        
        public void InitializeRoles(int playerNum)
        {
            Random.InitState(DateTime.Now.GetHashCode());
            
            var roles = (EGameRole[])Enum.GetValues(typeof(EGameRole));
            
            for (var i = 0; i < playerNum; i++)
            {
                var role = GetRole(roles);
                _roles.Enqueue(role);
            }
        }

        public bool TryGetGameRole(out EGameRole role)
        {
            return _roles.TryDequeue(out role);
        }
        
        private static EGameRole GetRandomRole(EGameRole[] gameRoles)
        {
            var random = Random.Range(0, gameRoles.Length);
                
            var role = gameRoles[random];

            return role;
        }

        private EGameRole GetRole(EGameRole[] gameRoles)
        {
            var random = GetRandomRole(gameRoles);

            if (random == EGameRole.Gunner && _roles.Contains(EGameRole.Gunner))
            {
                random = GetRole(gameRoles);
            }

            return random;
        }
    }
}