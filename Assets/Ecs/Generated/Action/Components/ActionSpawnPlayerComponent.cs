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
	public Ecs.Action.Components.SpawnPlayerComponent SpawnPlayer { get { return (Ecs.Action.Components.SpawnPlayerComponent)GetComponent(ActionComponentsLookup.SpawnPlayer); } }
	public bool HasSpawnPlayer { get { return HasComponent(ActionComponentsLookup.SpawnPlayer); } }

	public void AddSpawnPlayer(int newConnectionIndex)
	{
		var index = ActionComponentsLookup.SpawnPlayer;
		var component = (Ecs.Action.Components.SpawnPlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.SpawnPlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.ConnectionIndex = newConnectionIndex;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSpawnPlayer(int newConnectionIndex)
	{
		var index = ActionComponentsLookup.SpawnPlayer;
		var component = (Ecs.Action.Components.SpawnPlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.SpawnPlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.ConnectionIndex = newConnectionIndex;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySpawnPlayerTo(Ecs.Action.Components.SpawnPlayerComponent copyComponent)
	{
		var index = ActionComponentsLookup.SpawnPlayer;
		var component = (Ecs.Action.Components.SpawnPlayerComponent)CreateComponent(index, typeof(Ecs.Action.Components.SpawnPlayerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.ConnectionIndex = copyComponent.ConnectionIndex;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSpawnPlayer()
	{
		RemoveComponent(ActionComponentsLookup.SpawnPlayer);
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
public partial class ActionEntity : ISpawnPlayerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherSpawnPlayer;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> SpawnPlayer
	{
		get
		{
			if (_matcherSpawnPlayer == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.SpawnPlayer);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherSpawnPlayer = matcher;
			}

			return _matcherSpawnPlayer;
		}
	}
}