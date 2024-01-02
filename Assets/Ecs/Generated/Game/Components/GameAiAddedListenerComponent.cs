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
	public AiAddedListenerComponent AiAddedListener { get { return (AiAddedListenerComponent)GetComponent(GameComponentsLookup.AiAddedListener); } }
	public bool HasAiAddedListener { get { return HasComponent(GameComponentsLookup.AiAddedListener); } }

	public void AddAiAddedListener(System.Collections.Generic.List<IAiAddedListener> newValue)
	{
		var index = GameComponentsLookup.AiAddedListener;
		var component = (AiAddedListenerComponent)CreateComponent(index, typeof(AiAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceAiAddedListener(System.Collections.Generic.List<IAiAddedListener> newValue)
	{
		var index = GameComponentsLookup.AiAddedListener;
		var component = (AiAddedListenerComponent)CreateComponent(index, typeof(AiAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyAiAddedListenerTo(AiAddedListenerComponent copyComponent)
	{
		var index = GameComponentsLookup.AiAddedListener;
		var component = (AiAddedListenerComponent)CreateComponent(index, typeof(AiAddedListenerComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveAiAddedListener()
	{
		RemoveComponent(GameComponentsLookup.AiAddedListener);
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
public partial class GameEntity : IAiAddedListenerEntity { }

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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherAiAddedListener;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> AiAddedListener
	{
		get
		{
			if (_matcherAiAddedListener == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.AiAddedListener);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherAiAddedListener = matcher;
			}

			return _matcherAiAddedListener;
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
	public void AddAiAddedListener(IAiAddedListener value)
	{
		var listeners = HasAiAddedListener
			? AiAddedListener.value
			: new System.Collections.Generic.List<IAiAddedListener>();
		listeners.Add(value);
		ReplaceAiAddedListener(listeners);
	}

	public void RemoveAiAddedListener(IAiAddedListener value, bool removeComponentWhenEmpty = true)
	{
		var listeners = AiAddedListener.value;
		listeners.Remove(value);
		if (removeComponentWhenEmpty && listeners.Count == 0)
		{
			RemoveAiAddedListener();
		}
		else
		{
			ReplaceAiAddedListener(listeners);
		}
	}
}