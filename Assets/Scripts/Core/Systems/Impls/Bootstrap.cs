using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;
using Zenject;

namespace Core.Systems.Impls
{
    public class Bootstrap : ITickable, 
        IInitializable, 
        ILateTickable, 
        IFixedTickable, 
        IDisposable
    {
        private readonly Contexts _contexts;
        private readonly GameFeature _feature;
        private readonly List<ILateSystem> _late = new();
        private readonly List<IFixedSystem> _fixed = new();
        private readonly List<IResetable> _resetables = new();
        private bool _isInitialized;
        private bool _isPaused;
        
        public Bootstrap(
            List<ISystem> systems,
            Contexts contexts,
            GameFeature feature,
            List<IResetable> resetables
        )
        {
            _contexts = contexts; 
            _feature = feature;
            _resetables = resetables;
            
            for (int i = 0; i < systems.Count; i++)
            {
                var system = systems[i];

                _feature.Add(system);
                
                if(system is IFixedSystem fixedUpdate)
                    _fixed.Add(fixedUpdate);
                
                if(system is ILateSystem late)
                    _late.Add(late);
            }
        }
        
        public void Initialize()
        {
            if(_isInitialized)
                return;
            
            _feature.Initialize();
            _isInitialized = true;
        }
        
        public void Tick()
        {
            if (_isPaused)
                return;
            
            _feature.Update();
            _feature.Execute();
        }

        public void LateTick()
        {
            if (_isPaused)
                return;
            
            foreach (var lateUpdateSystem in _late)
            {
                lateUpdateSystem.Late();
            }
            
            _feature.LateUpdate();
            _feature.Cleanup();
        }

        public void FixedTick()
        {
            if (_isPaused)
                return;
            
            _feature.FixedUpdate();
            
            foreach (var fixedUpdate in _fixed)
            {
                fixedUpdate.Fixed();
            }
        }

        public void Reset()
        {
            _isPaused = true;

            _feature.Deactivate();
            foreach (var context in _contexts.AllContexts)
            {
                context.DestroyAllEntities();
                context.ResetCreationIndex();
            }

            foreach (var resetable in _resetables)
                resetable.Reset();

            _feature.Activate();
            _isInitialized = false;
            Initialize();

            _isPaused = false;
        }

        public void Dispose()
        {
            _feature.Deactivate();
            _contexts.Reset();
        }
    }
}