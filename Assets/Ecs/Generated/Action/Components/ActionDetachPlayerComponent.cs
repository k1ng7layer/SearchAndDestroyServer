//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity
{
	public Ecs.Action.Components.DetachPlayerComponent DetachPlayer { get { return (Ecs.Action.Components.DetachPlayerComponent)GetComponent(ActionComponentsLookup.DetachPlayer); } }
	public bool HasDetachPlayer { get { return HasComponent(ActionComponentsLookup.DetachPlayer); } }

	public void AddDetachPlayer(Ecs.Uid.Uid newPlayer)
	{
		var index = ActionComponentsLookup.DetachPlayer;
		var component = (Ecs.Action.Components.DetachPlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.DetachPlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Player = newPlayer;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceDetachPlayer(Ecs.Uid.Uid newPlayer)
	{
		var index = ActionComponentsLookup.DetachPlayer;
		var component = (Ecs.Action.Components.DetachPlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.DetachPlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Player = newPlayer;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyDetachPlayerTo(Ecs.Action.Components.DetachPlayerComponent copyComponent)
	{
		var index = ActionComponentsLookup.DetachPlayer;
		var component = (Ecs.Action.Components.DetachPlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.DetachPlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Player = copyComponent.Player;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveDetachPlayer()
	{
		RemoveComponent(ActionComponentsLookup.DetachPlayer);
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ActionEntity : IDetachPlayerEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ActionMatcher
{
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherDetachPlayer;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> DetachPlayer
	{
		get
		{
			if (_matcherDetachPlayer == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.DetachPlayer);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherDetachPlayer = matcher;
			}

			return _matcherDetachPlayer;
		}
	}
}
