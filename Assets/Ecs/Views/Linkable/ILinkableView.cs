using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable
{
    public interface ILinkableView
    {
        Transform Transform { get; }

        void Link(IEntity entity, IContext context);
    }
}