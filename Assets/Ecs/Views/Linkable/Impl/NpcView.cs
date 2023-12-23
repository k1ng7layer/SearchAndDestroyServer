using JCMG.EntitasRedux;
using UnityEngine;
using UnityEngine.AI;

namespace Ecs.Views.Linkable.Impl
{
    public class NpcView : NetworkObjectView, 
        IDestinationAddedListener,
        IDestinationRemovedListener
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);
        
            var selfEntity = (GameEntity)entity;
            
            selfEntity.AddDestinationAddedListener(this);
            selfEntity.AddDestinationRemovedListener(this);
        }   

        public void OnDestinationAdded(GameEntity entity, Vector3 value)
        {
            _navMeshAgent.SetDestination(value);
        }

        public void OnDestinationRemoved(GameEntity entity)
        {
            _navMeshAgent.SetDestination(transform.position);
        }
    }
}