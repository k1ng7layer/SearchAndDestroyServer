using Ecs.Uid;

namespace Ecs.Game.Extensions
{
    public static class GameExtensions
    {
        public static GameEntity CreatePlayer(this GameContext context, uint netId)
        {
            var entity = context.CreateEntity();

            entity.IsPlayer = true;
            entity.AddNetworkId(netId);
            entity.AddUid(UidGenerator.Next());

            return entity;
        }
    }
}