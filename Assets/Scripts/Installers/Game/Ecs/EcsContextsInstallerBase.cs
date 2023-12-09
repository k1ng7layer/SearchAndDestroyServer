using Core.Systems.Impls;
using JCMG.EntitasRedux;
using Zenject;

namespace Installers.Game.Ecs
{
    public abstract class EcsContextsInstallerBase : MonoInstaller
    {
        private Contexts _contexts;
        
        public override void InstallBindings()
        {
            _contexts = Contexts.SharedInstance;
            Container.BindInstance(_contexts).WhenInjectedInto<Bootstrap>();
            Container.BindInterfacesTo<Bootstrap>().AsSingle().NonLazy();
            BindContexts();
        }

        protected abstract void BindContexts();

        protected void BindContext<T>() where T : IContext
        {
            
            foreach (var ctx in _contexts.AllContexts)
            {
                if (ctx is T context)
                {
                    Container.BindInterfacesAndSelfTo<T>().FromInstance(context).AsSingle();
                }
            }
        }
        
        protected void BindEventSystem<TEventSystem>()
            where TEventSystem : Feature
        {
            Container.BindInterfacesTo<TEventSystem>().AsSingle().WithArguments(_contexts);
        }
    }
}