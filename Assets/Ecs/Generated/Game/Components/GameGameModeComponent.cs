//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

	public GameEntity GameModeEntity { get { return GetGroup(GameMatcher.GameMode).GetSingleEntity(); } }
	public Ecs.Game.Components.GameModeComponent GameMode { get { return GameModeEntity.GameMode; } }
	public bool HasGameMode { get { return GameModeEntity != null; } }

	public GameEntity SetGameMode(Utils.EGameMode newValue)
	{
		if (HasGameMode)
		{
			throw new JCMG.EntitasRedux.EntitasReduxException(
				"Could not set GameMode!\n" +
				this +
				" already has an entity with Ecs.Game.Components.GameModeComponent!",
				"You should check if the context already has a GameModeEntity before setting it or use context.ReplaceGameMode().");
		}
		var entity = CreateEntity();
		#if !ENTITAS_REDUX_NO_IMPL
		entity.AddGameMode(newValue);
		#endif
		return entity;
	}

	public void ReplaceGameMode(Utils.EGameMode newValue)
	{
		#if !ENTITAS_REDUX_NO_IMPL
		var entity = GameModeEntity;
		if (entity == null)
		{
			entity = SetGameMode(newValue);
		}
		else
		{
			entity.ReplaceGameMode(newValue);
		}
		#endif
	}

	public void RemoveGameMode()
	{
		GameModeEntity.Destroy();
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
public partial class GameEntity
{
	public Ecs.Game.Components.GameModeComponent GameMode { get { return (Ecs.Game.Components.GameModeComponent)GetComponent(GameComponentsLookup.GameMode); } }
	public bool HasGameMode { get { return HasComponent(GameComponentsLookup.GameMode); } }

	public void AddGameMode(Utils.EGameMode newValue)
	{
		var index = GameComponentsLookup.GameMode;
		var component = (Ecs.Game.Components.GameModeComponent)CreateComponent(index, typeof(Ecs.Game.Components.GameModeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceGameMode(Utils.EGameMode newValue)
	{
		var index = GameComponentsLookup.GameMode;
		var component = (Ecs.Game.Components.GameModeComponent)CreateComponent(index, typeof(Ecs.Game.Components.GameModeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyGameModeTo(Ecs.Game.Components.GameModeComponent copyComponent)
	{
		var index = GameComponentsLookup.GameMode;
		var component = (Ecs.Game.Components.GameModeComponent)CreateComponent(index, typeof(Ecs.Game.Components.GameModeComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.Value = copyComponent.Value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveGameMode()
	{
		RemoveComponent(GameComponentsLookup.GameMode);
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
public partial class GameEntity : IGameModeEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherGameMode;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> GameMode
	{
		get
		{
			if (_matcherGameMode == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameMode);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherGameMode = matcher;
			}

			return _matcherGameMode;
		}
	}
}