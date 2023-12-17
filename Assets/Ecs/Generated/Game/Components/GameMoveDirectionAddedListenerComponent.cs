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
	public MoveDirectionAddedListenerComponent MoveDirectionAddedListener { get { return (MoveDirectionAddedListenerComponent)GetComponent(GameComponentsLookup.MoveDirectionAddedListener); } }
	public bool HasMoveDirectionAddedListener { get { return HasComponent(GameComponentsLookup.MoveDirectionAddedListener); } }

	public void AddMoveDirectionAddedListener(System.Collections.Generic.List<IMoveDirectionAddedListener> newValue)
	{
		var index = GameComponentsLookup.MoveDirectionAddedListener;
		var component = (MoveDirectionAddedListenerComponent)CreateComponent(index, typeof(MoveDirectionAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceMoveDirectionAddedListener(System.Collections.Generic.List<IMoveDirectionAddedListener> newValue)
	{
		var index = GameComponentsLookup.MoveDirectionAddedListener;
		var component = (MoveDirectionAddedListenerComponent)CreateComponent(index, typeof(MoveDirectionAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyMoveDirectionAddedListenerTo(MoveDirectionAddedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.MoveDirectionAddedListener;
		var component = (MoveDirectionAddedListenerComponent)CreateComponent(index, typeof(MoveDirectionAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveMoveDirectionAddedListener()
	{
		RemoveComponent(GameComponentsLookup.MoveDirectionAddedListener);
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
public partial class GameEntity : IMoveDirectionAddedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherMoveDirectionAddedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> MoveDirectionAddedListener
	{
		get
		{
			if (_matcherMoveDirectionAddedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoveDirectionAddedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherMoveDirectionAddedListener = matcher;
			}

			return _matcherMoveDirectionAddedListener;
		}
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
	public void AddMoveDirectionAddedListener(IMoveDirectionAddedListener value)
	{
		var listeners = HasMoveDirectionAddedListener
			? MoveDirectionAddedListener.value
			: new System.Collections.Generic.List<IMoveDirectionAddedListener>();
		listeners.Add(value);
		ReplaceMoveDirectionAddedListener(listeners);
	}

	public void RemoveMoveDirectionAddedListener(IMoveDirectionAddedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = MoveDirectionAddedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveMoveDirectionAddedListener();
		}
		else
		{
			ReplaceMoveDirectionAddedListener(listeners);
		}
	}
}
