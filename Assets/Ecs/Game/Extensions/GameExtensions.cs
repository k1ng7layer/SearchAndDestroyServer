using Ecs.Uid;
using UnityEngine;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        public static GameEntity CreatePlayer(this GameContext context, 
            int netId,
            Vector3 position, 
            Quaternion rotation
        )
        {
            var entity = context.CreateEntity();

            entity.IsPlayer = true;
            entity.AddConnectionId(netId);
            entity.AddUid(UidGenerator.Next());
            entity.AddPosition(position);
            entity.AddRotation(rotation);

            return entity;
        }
    }
}