using System.Collections.Generic;

namespace Ecs.EntityRepository
{
    public interface ILinkedEntityRepository
    {
        bool TryGet(int id, out GameEntity entity);
        
        IEnumerable<GameEntity> GetAllItems();
		
        void Add(int id, GameEntity item);
        GameEntity Get(int id);
        bool HasItem(int id);
        void Update(int id, GameEntity item);
        void Delete(int id);
    }
}