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
	public Ecs.Action.Components.SpawnNpcComponent SpawnNpc { get { return (Ecs.Action.Components.SpawnNpcComponent)GetComponent(ActionComponentsLookup.SpawnNpc); } }
	public bool HasSpawnNpc { get { return HasComponent(ActionComponentsLookup.SpawnNpc); } }

	public void AddSpawnNpc(UnityEngine.Vector3 newPosition, UnityEngine.Quaternion newRotation)
	{
		var index = ActionComponentsLookup.SpawnNpc;
		var component = (Ecs.Action.Components.SpawnNpcComponent)CreateComponent(index, typeof(Ecs.Action.Components.SpawnNpcComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Position = newPosition;
		component.Rotation = newRotation;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSpawnNpc(UnityEngine.Vector3 newPosition, UnityEngine.Quaternion newRotation)
	{
		var index = ActionComponentsLookup.SpawnNpc;
		var component = (Ecs.Action.Components.SpawnNpcComponent)CreateComponent(index, typeof(Ecs.Action.Components.SpawnNpcComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Position = newPosition;
		component.Rotation = newRotation;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySpawnNpcTo(Ecs.Action.Components.SpawnNpcComponent copyComponent)
	{
		var index = ActionComponentsLookup.SpawnNpc;
		var component = (Ecs.Action.Components.SpawnNpcComponent)CreateComponent(index, typeof(Ecs.Action.Components.SpawnNpcComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Position = copyComponent.Position;
		component.Rotation = copyComponent.Rotation;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSpawnNpc()
	{
		RemoveComponent(ActionComponentsLookup.SpawnNpc);
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
public partial class ActionEntity : ISpawnNpcEntity { }

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
	static JCMG.EntitasRedux.IMatcher<ActionEntity> _matcherSpawnNpc;

	public static JCMG.EntitasRedux.IMatcher<ActionEntity> SpawnNpc
	{
		get
		{
			if (_matcherSpawnNpc == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<ActionEntity>)JCMG.EntitasRedux.Matcher<ActionEntity>.AllOf(ActionComponentsLookup.SpawnNpc);
				matcher.ComponentNames = ActionComponentsLookup.ComponentNames;
				_matcherSpawnNpc = matcher;
			}

			return _matcherSpawnNpc;
		}
	}
}
