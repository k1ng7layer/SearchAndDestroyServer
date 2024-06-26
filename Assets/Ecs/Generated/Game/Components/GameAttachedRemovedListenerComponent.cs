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
	public AttachedRemovedListenerComponent AttachedRemovedListener { get { return (AttachedRemovedListenerComponent)GetComponent(GameComponentsLookup.AttachedRemovedListener); } }
	public bool HasAttachedRemovedListener { get { return HasComponent(GameComponentsLookup.AttachedRemovedListener); } }

	public void AddAttachedRemovedListener(System.Collections.Generic.List<IAttachedRemovedListener> newValue)
	{
		var index = GameComponentsLookup.AttachedRemovedListener;
		var component = (AttachedRemovedListenerComponent)CreateComponent(index, typeof(AttachedRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceAttachedRemovedListener(System.Collections.Generic.List<IAttachedRemovedListener> newValue)
	{
		var index = GameComponentsLookup.AttachedRemovedListener;
		var component = (AttachedRemovedListenerComponent)CreateComponent(index, typeof(AttachedRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyAttachedRemovedListenerTo(AttachedRemovedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.AttachedRemovedListener;
		var component = (AttachedRemovedListenerComponent)CreateComponent(index, typeof(AttachedRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveAttachedRemovedListener()
	{
		RemoveComponent(GameComponentsLookup.AttachedRemovedListener);
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
public partial class GameEntity : IAttachedRemovedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherAttachedRemovedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> AttachedRemovedListener
	{
		get
		{
			if (_matcherAttachedRemovedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttachedRemovedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherAttachedRemovedListener = matcher;
			}

			return _matcherAttachedRemovedListener;
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
	public void AddAttachedRemovedListener(IAttachedRemovedListener value)
	{
		var listeners = HasAttachedRemovedListener
			? AttachedRemovedListener.value
			: new System.Collections.Generic.List<IAttachedRemovedListener>();
		listeners.Add(value);
		ReplaceAttachedRemovedListener(listeners);
	}

	public void RemoveAttachedRemovedListener(IAttachedRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = AttachedRemovedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveAttachedRemovedListener();
		}
		else
		{
			ReplaceAttachedRemovedListener(listeners);
		}
	}
}
