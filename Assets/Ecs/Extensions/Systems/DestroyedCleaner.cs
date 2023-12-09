﻿using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Extensions.Systems
{
    public sealed class DestroyedCleaner<TContext, UEntity> : ICleanupSystem
        where UEntity : class, IEntity
        where TContext : class, IContext<UEntity>
    {
        private IGroup<UEntity> _group;
        private List<UEntity> _list = new List<UEntity>();

        public DestroyedCleaner(TContext context, IMatcher<UEntity> matcher)
        {
            _group = context.GetGroup(matcher);
        }

        public void Cleanup()
        {
            _list = _group.GetEntities(_list);
            for (var i = 0; i < _list.Count; i++)
                _list[i].Destroy();
        }
    }
}