using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public class PlayerView : NetworkObjectView, 
        IMoveDirectionAddedListener
    {
        [SerializeField] private CharacterController _characterController;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            var self = (GameEntity)entity;
            
            self.AddMoveDirectionAddedListener(this);
        }

        public void OnMoveDirectionAdded(GameEntity entity, Vector3 value)
        {
            _characterController.Move(value * 3f* Time.deltaTime);
        }
    }
}