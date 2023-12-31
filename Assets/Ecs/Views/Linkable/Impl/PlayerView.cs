using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : NetworkObjectView, 
        IMoveDirectionAddedListener,
        IAttachedAddedListener,
        IAttachedRemovedListener
    {
        [SerializeField] private CharacterController _characterController;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            var self = (GameEntity)entity;
            
            self.AddMoveDirectionAddedListener(this);
            self.AddAttachedAddedListener(this);
            self.AddAttachedRemovedListener(this);
        }

        public void OnMoveDirectionAdded(GameEntity entity, Vector3 value)
        {
            _characterController.Move(value * 3f* Time.deltaTime);
        }

        public void OnAttachedAdded(GameEntity entity, Uid.Uid carrier)
        {
            _characterController.enabled = false;
        }

        public void OnAttachedRemoved(GameEntity entity)
        {
            _characterController.enabled = true;
        }
    }
}