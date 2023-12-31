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
	public AiRemovedListenerComponent AiRemovedListener { get { return (AiRemovedListenerComponent)GetComponent(GameComponentsLookup.AiRemovedListener); } }
	public bool HasAiRemovedListener { get { return HasComponent(GameComponentsLookup.AiRemovedListener); } }

	public void AddAiRemovedListener(System.Collections.Generic.List<IAiRemovedListener> newValue)
	{
		var index = GameComponentsLookup.AiRemovedListener;
		var component = (AiRemovedListenerComponent)CreateComponent(index, typeof(AiRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceAiRemovedListener(System.Collections.Generic.List<IAiRemovedListener> newValue)
	{
		var index = GameComponentsLookup.AiRemovedListener;
		var component = (AiRemovedListenerComponent)CreateComponent(index, typeof(AiRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyAiRemovedListenerTo(AiRemovedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.AiRemovedListener;
		var component = (AiRemovedListenerComponent)CreateComponent(index, typeof(AiRemovedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveAiRemovedListener()
	{
		RemoveComponent(GameComponentsLookup.AiRemovedListener);
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
public partial class GameEntity : IAiRemovedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherAiRemovedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> AiRemovedListener
	{
		get
		{
			if (_matcherAiRemovedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.AiRemovedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherAiRemovedListener = matcher;
			}

			return _matcherAiRemovedListener;
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
	public void AddAiRemovedListener(IAiRemovedListener value)
	{
		var listeners = HasAiRemovedListener
			? AiRemovedListener.value
			: new System.Collections.Generic.List<IAiRemovedListener>();
		listeners.Add(value);
		ReplaceAiRemovedListener(listeners);
	}

	public void RemoveAiRemovedListener(IAiRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = AiRemovedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveAiRemovedListener();
		}
		else
		{
			ReplaceAiRemovedListener(listeners);
		}
	}
}
