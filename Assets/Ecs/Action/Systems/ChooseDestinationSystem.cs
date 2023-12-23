using System.Collections.Generic;
using JCMG.EntitasRedux;
using Settings.Npc;
using UnityEngine;
using UnityEngine.AI;

namespace Ecs.Action.Systems
{
    public class ChooseDestinationSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly INpcSettings _npcSettings;

        public ChooseDestinationSystem(
            ActionContext action, 
            GameContext game,
            INpcSettings npcSettings
        ) : base(action)
        {
            _game = game;
            _npcSettings = npcSettings;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.ChooseDestination);

        protected override bool Filter(ActionEntity entity) => entity.HasChooseDestination && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var npcUid = entity.ChooseDestination.NpcUid;
                var npc = _game.GetEntityWithUid(npcUid);
                var ncpPos = npc.Position.Value;
                //Random.InitState(100);
                var randomRadius = Random.Range(_npcSettings.DestinationChooseMinRadius, _npcSettings.DestinationChooseMaxRadius);
                var randomPos = new Vector2(ncpPos.x, ncpPos.y) + (Random.insideUnitCircle * randomRadius);
                
                var areaMaskFromName = 1 << NavMesh.GetAreaFromName("Walkable");
                
                var result1 = NavMesh.SamplePosition(new Vector3(randomPos.x, ncpPos.y, randomPos.y), 
                    out var hit1, 
                    _npcSettings.DestinationChooseMaxRadius, areaMaskFromName);
                
                if (!result1)
                    continue;
                
                //Debug.Log($"Choose destination: {hit1.position}");
                npc.ReplaceDestination(hit1.position);
            }
        }
    }
}