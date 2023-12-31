using JCMG.EntitasRedux;
using UnityEngine;
using UnityEngine.AI;

namespace Ecs.Views.Linkable.Impl
{
    public class NpcView : NetworkObjectView, 
        IDestinationAddedListener,
        IDestinationRemovedListener,
        IAiAddedListener,
        IAiRemovedListener,
        IMoveDirectionAddedListener
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);
        
            var selfEntity = (GameEntity)entity;
            
            selfEntity.AddDestinationAddedListener(this);
            selfEntity.AddDestinationRemovedListener(this);
            selfEntity.AddAiAddedListener(this);
            selfEntity.AddAiRemovedListener(this);
            selfEntity.AddMoveDirectionAddedListener(this);
        }   

        public void OnDestinationAdded(GameEntity entity, Vector3 value)
        {
            _navMeshAgent.SetDestination(value);
        }

        public void OnDestinationRemoved(GameEntity entity)
        {
            _navMeshAgent.SetDestination(transform.position);
        }

        public void OnAiAdded(GameEntity entity)
        {
            _characterController.enabled = false;
            _navMeshAgent.isStopped = false;
        }

        public void OnAiRemoved(GameEntity entity)
        {
            _navMeshAgent.isStopped = true;
            _characterController.enabled = true;
        }
        
        public void OnMoveDirectionAdded(GameEntity entity, Vector3 value)
        {
            _characterController.Move(value * 3f* Time.deltaTime);
        }
    }
}