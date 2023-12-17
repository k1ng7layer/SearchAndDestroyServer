//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameCountdownAddedEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{
	readonly System.Collections.Generic.List<IGameCountdownAddedListener> _listenerBuffer;

	public GameCountdownAddedEventSystem(Contexts contexts) : base(contexts.Game)
	{
		_listenerBuffer = new System.Collections.Generic.List<IGameCountdownAddedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Added(GameMatcher.GameCountdown)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.HasGameCountdown && entity.HasGameCountdownAddedListener;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.GameCountdown;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(e.GameCountdownAddedListener.value);
			foreach (var listener in _listenerBuffer)
			{
				listener.OnGameCountdownAdded(e, component.Value);
			}
		}
	}
}
