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
	public InputAddedListenerComponent InputAddedListener { get { return (InputAddedListenerComponent)GetComponent(GameComponentsLookup.InputAddedListener); } }
	public bool HasInputAddedListener { get { return HasComponent(GameComponentsLookup.InputAddedListener); } }

	public void AddInputAddedListener(System.Collections.Generic.List<IInputAddedListener> newValue)
	{
		var index = GameComponentsLookup.InputAddedListener;
		var component = (InputAddedListenerComponent)CreateComponent(index, typeof(InputAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceInputAddedListener(System.Collections.Generic.List<IInputAddedListener> newValue)
	{
		var index = GameComponentsLookup.InputAddedListener;
		var component = (InputAddedListenerComponent)CreateComponent(index, typeof(InputAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyInputAddedListenerTo(InputAddedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.InputAddedListener;
		var component = (InputAddedListenerComponent)CreateComponent(index, typeof(InputAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveInputAddedListener()
	{
		RemoveComponent(GameComponentsLookup.InputAddedListener);
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
public partial class GameEntity : IInputAddedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherInputAddedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> InputAddedListener
	{
		get
		{
			if (_matcherInputAddedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.InputAddedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherInputAddedListener = matcher;
			}

			return _matcherInputAddedListener;
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
	public void AddInputAddedListener(IInputAddedListener value)
	{
		var listeners = HasInputAddedListener
			? InputAddedListener.value
			: new System.Collections.Generic.List<IInputAddedListener>();
		listeners.Add(value);
		ReplaceInputAddedListener(listeners);
	}

	public void RemoveInputAddedListener(IInputAddedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = InputAddedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveInputAddedListener();
		}
		else
		{
			ReplaceInputAddedListener(listeners);
		}
	}
}
