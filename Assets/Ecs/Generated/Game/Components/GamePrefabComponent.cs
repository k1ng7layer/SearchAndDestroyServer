//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	public Ecs.Game.Components.PrefabComponent Prefab { get { return (Ecs.Game.Components.PrefabComponent)GetComponent(GameComponentsLookup.Prefab); } }
	public bool HasPrefab { get { return HasComponent(GameComponentsLookup.Prefab); } }

	public void AddPrefab(string newName)
	{
		var index = GameComponentsLookup.Prefab;
		var component = (Ecs.Game.Components.PrefabComponent)CreateComponent(index, typeof(Ecs.Game.Components.PrefabComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Name = newName;
		#endif
		AddComponent(index, component);
	}

	public void ReplacePrefab(string newName)
	{
		var index = GameComponentsLookup.Prefab;
		var component = (Ecs.Game.Components.PrefabComponent)CreateComponent(index, typeof(Ecs.Game.Components.PrefabComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Name = newName;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyPrefabTo(Ecs.Game.Components.PrefabComponent copyComponent)
	{
		var index = GameComponentsLookup.Prefab;
		var component = (Ecs.Game.Components.PrefabComponent)CreateComponent(index, typeof(Ecs.Game.Components.PrefabComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Name = copyComponent.Name;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemovePrefab()
	{
		RemoveComponent(GameComponentsLookup.Prefab);
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
public partial class GameEntity : IPrefabEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherPrefab;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Prefab
	{
		get
		{
			if (_matcherPrefab == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Prefab);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherPrefab = matcher;
			}

			return _matcherPrefab;
		}
	}
}
