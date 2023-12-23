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
	public DestinationAddedListenerComponent DestinationAddedListener { get { return (DestinationAddedListenerComponent)GetComponent(GameComponentsLookup.DestinationAddedListener); } }
	public bool HasDestinationAddedListener { get { return HasComponent(GameComponentsLookup.DestinationAddedListener); } }

	public void AddDestinationAddedListener(System.Collections.Generic.List<IDestinationAddedListener> newValue)
	{
		var index = GameComponentsLookup.DestinationAddedListener;
		var component = (DestinationAddedListenerComponent)CreateComponent(index, typeof(DestinationAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceDestinationAddedListener(System.Collections.Generic.List<IDestinationAddedListener> newValue)
	{
		var index = GameComponentsLookup.DestinationAddedListener;
		var component = (DestinationAddedListenerComponent)CreateComponent(index, typeof(DestinationAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyDestinationAddedListenerTo(DestinationAddedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.DestinationAddedListener;
		var component = (DestinationAddedListenerComponent)CreateComponent(index, typeof(DestinationAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveDestinationAddedListener()
	{
		RemoveComponent(GameComponentsLookup.DestinationAddedListener);
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
public partial class GameEntity : IDestinationAddedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherDestinationAddedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> DestinationAddedListener
	{
		get
		{
			if (_matcherDestinationAddedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.DestinationAddedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherDestinationAddedListener = matcher;
			}

			return _matcherDestinationAddedListener;
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
	public void AddDestinationAddedListener(IDestinationAddedListener value)
	{
		var listeners = HasDestinationAddedListener
			? DestinationAddedListener.value
			: new System.Collections.Generic.List<IDestinationAddedListener>();
		listeners.Add(value);
		ReplaceDestinationAddedListener(listeners);
	}

	public void RemoveDestinationAddedListener(IDestinationAddedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = DestinationAddedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveDestinationAddedListener();
		}
		else
		{
			ReplaceDestinationAddedListener(listeners);
		}
	}
}