//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class AttachedAddedEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{
	readonly System.Collections.Generic.List<IAttachedAddedListener> _listenerBuffer;

	public AttachedAddedEventSystem(Contexts contexts) : base(contexts.Game)
	{
		_listenerBuffer = new System.Collections.Generic.List<IAttachedAddedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Added(GameMatcher.Attached)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.HasAttached && entity.HasAttachedAddedListener;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.Attached;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(e.AttachedAddedListener.value);
			foreach (var listener in _listenerBuffer)
			{
				listener.OnAttachedAdded(e, component.Carrier);
			}
		}
	}
}
