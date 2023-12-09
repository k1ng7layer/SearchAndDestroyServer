using Core.Systems.Impls;
using Ecs.Game.Systems;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSystems();
        }

        private void BindSystems()
        {
        }
    }
}