using System;
using JCMG.EntitasRedux;
using Mirror;
using UnityEditor;
using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    [RequireComponent(typeof(NetworkIdentity))]
    [RequireComponent(typeof(EntityLink))]
    public class NetworkObjectView : NetworkBehaviour, ILinkableView, 
        ILinkRemovedListener,
        IPositionAddedListener,
        IRotationAddedListener
    {
        [SerializeField] private EntityLink entityLink;
		
        private GameEntity _entity;
        private bool _entityDestroyed;
        private bool _destroyed;
        protected bool Destroyed => _destroyed;

        public int Hash => transform.GetHashCode();

        public Transform Transform => !_destroyed ? transform : null;

        public virtual void Link(IEntity entity, IContext context)
        {
            _entityDestroyed = false;
            _entity = (GameEntity)entity;
            entityLink.Link(_entity);
            _entity.OnDestroyEntity += OnDestroyEntity;
            _entity.AddLinkRemovedListener(this);
            _entity.AddPositionAddedListener(this);
            _entity.AddRotationAddedListener(this);
            _entity.AddTransform(transform);
            
            if (_entity.HasRotation)
                transform.rotation = _entity.Rotation.Value;

            if (_entity.HasPosition)
                transform.position = _entity.Position.Value;
        }

        private void OnDestroyEntity(IEntity entity)
        {
            _entityDestroyed = true;
            entity.OnDestroyEntity -= OnDestroyEntity;

            if (entityLink.Entity != null)
                entityLink.Unlink();

            if (!_destroyed)
                DestroyObject();
            
            //NetworkServer.Destroy(gameObject);
        }

        protected virtual void DestroyObject()
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
                Destroy(gameObject);
            else
                DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
        }

        private void OnDestroy()
        {
            _destroyed = true;
            if (!_entityDestroyed && _entity != null)
                OnDestroyEntity(_entity);

            InternalOnDestroy();
        }

        protected virtual void InternalOnDestroy()
        {
            // NetworkServer.Destroy(gameObject);
        }

        public void OnLinkRemoved(GameEntity entity)
        {
            OnDestroyEntity(entity);
        }

        public virtual void OnPositionAdded(GameEntity entity, Vector3 value)
        {
            transform.position = value;
        }

        public virtual void OnRotationAdded(GameEntity entity, Quaternion value)
        {
            transform.rotation = value;
        }

        private void Update()
        {
            if (_entity != null)
                _entity.Position.Value = transform.position;
            
            if (_entity != null)
                _entity.Rotation.Value = transform.rotation;
        }
    }
}