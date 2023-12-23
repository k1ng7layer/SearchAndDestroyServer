using JCMG.EntitasRedux;
using Settings.Npc;
using UnityEngine;
using Zenject;

namespace Ecs.Game.Systems
{
    public class CheckDestinationSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;

        private readonly ActionContext _action;
        private readonly INpcSettings _npcSettings;
        private readonly IGroup<GameEntity> _npcGroup;

        public CheckDestinationSystem(GameContext game, ActionContext action, INpcSettings npcSettings)
        {
            _action = action;
            _npcSettings = npcSettings;
            _npcGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Npc).NoneOf(GameMatcher.Infected));
        }
        
        public void Update()
        {
            var npcPlayers = EntityPool.Spawn();
            _npcGroup.GetEntities(npcPlayers);

            foreach (var npc in npcPlayers)
            {
                if (!npc.HasDestination)
                    continue;

                var destination = npc.Destination.Value;
                var npcPosition = npc.Position.Value;
                var checkDistance = _npcSettings.DestinationCheckDistance;

                var dist2 = (destination - npcPosition).sqrMagnitude;
                
                //Debug.Log($"Check destination: {dist2}, check: {checkDistance * checkDistance}");
                
                if (dist2 <= checkDistance * checkDistance)
                {
                    var npcUid = npc.Uid.Value;
                    
                    npc.RemoveDestination();
                    
                    _action.CreateEntity().AddChooseDestination(npcUid);
                }
            }
            
            EntityPool.Despawn(npcPlayers);
        }
    }
}