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
	public AttachedAddedListenerComponent AttachedAddedListener { get { return (AttachedAddedListenerComponent)GetComponent(GameComponentsLookup.AttachedAddedListener); } }
	public bool HasAttachedAddedListener { get { return HasComponent(GameComponentsLookup.AttachedAddedListener); } }

	public void AddAttachedAddedListener(System.Collections.Generic.List<IAttachedAddedListener> newValue)
	{
		var index = GameComponentsLookup.AttachedAddedListener;
		var component = (AttachedAddedListenerComponent)CreateComponent(index, typeof(AttachedAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceAttachedAddedListener(System.Collections.Generic.List<IAttachedAddedListener> newValue)
	{
		var index = GameComponentsLookup.AttachedAddedListener;
		var component = (AttachedAddedListenerComponent)CreateComponent(index, typeof(AttachedAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyAttachedAddedListenerTo(AttachedAddedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.AttachedAddedListener;
		var component = (AttachedAddedListenerComponent)CreateComponent(index, typeof(AttachedAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveAttachedAddedListener()
	{
		RemoveComponent(GameComponentsLookup.AttachedAddedListener);
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
public partial class GameEntity : IAttachedAddedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherAttachedAddedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> AttachedAddedListener
	{
		get
		{
			if (_matcherAttachedAddedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttachedAddedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherAttachedAddedListener = matcher;
			}

			return _matcherAttachedAddedListener;
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
	public void AddAttachedAddedListener(IAttachedAddedListener value)
	{
		var listeners = HasAttachedAddedListener
			? AttachedAddedListener.value
			: new System.Collections.Generic.List<IAttachedAddedListener>();
		listeners.Add(value);
		ReplaceAttachedAddedListener(listeners);
	}

	public void RemoveAttachedAddedListener(IAttachedAddedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = AttachedAddedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveAttachedAddedListener();
		}
		else
		{
			ReplaceAttachedAddedListener(listeners);
		}
	}
}
