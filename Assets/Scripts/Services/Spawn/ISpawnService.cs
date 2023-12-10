using Ecs.Views.Linkable;

namespace Services.Spawn
{
    public interface ISpawnService
    {
        ILinkableView Spawn(GameEntity entity);
    }
}