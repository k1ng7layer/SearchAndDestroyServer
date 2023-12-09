//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : JCMG.EntitasRedux.IContexts
{
	#if UNITY_EDITOR

	static Contexts()
	{
		UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
	}

	/// <summary>
	/// Invoked when the Unity Editor has a <see cref="UnityEditor.PlayModeStateChange"/> change.
	/// </summary>
	private static void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange playModeStateChange)
	{
		// When entering edit-mode, reset all static state so that it does not interfere with the
		// next play-mode session.
		if (playModeStateChange == UnityEditor.PlayModeStateChange.EnteredEditMode)
		{
			_sharedInstance = null;
		}
	}

	#endif

	public static Contexts SharedInstance
	{
		get
		{
			if (_sharedInstance == null)
			{
				_sharedInstance = new Contexts();
			}

			return _sharedInstance;
		}
		set	{ _sharedInstance = value; }
	}

	static Contexts _sharedInstance;

	public ActionContext Action { get; set; }
	public GameContext Game { get; set; }
	public InputContext Input { get; set; }

	public JCMG.EntitasRedux.IContext[] AllContexts { get { return new JCMG.EntitasRedux.IContext [] { Action, Game, Input }; } }

	public Contexts()
	{
		Action = new ActionContext();
		Game = new GameContext();
		Input = new InputContext();

		var postConstructors = System.Linq.Enumerable.Where(
			GetType().GetMethods(),
			method => System.Attribute.IsDefined(method, typeof(JCMG.EntitasRedux.PostConstructorAttribute))
		);

		foreach (var postConstructor in postConstructors)
		{
			postConstructor.Invoke(this, null);
		}
	}

	public void Reset()
	{
		var contexts = AllContexts;
		for (int i = 0; i < contexts.Length; i++)
		{
			contexts[i].Reset();
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
public partial class Contexts
{
	public const string ConnectionId = "ConnectionId";
	public const string Uid = "Uid";

	[JCMG.EntitasRedux.PostConstructor]
	public void InitializeEntityIndices()
	{
		Game.AddEntityIndex(new JCMG.EntitasRedux.PrimaryEntityIndex<GameEntity, int>(
			ConnectionId,
			Game.GetGroup(GameMatcher.ConnectionId),
			(e, c) => ((Ecs.Game.Components.ConnectionIdComponent)c).Value));

		Game.AddEntityIndex(new JCMG.EntitasRedux.PrimaryEntityIndex<GameEntity, Ecs.Uid.Uid>(
			Uid,
			Game.GetGroup(GameMatcher.Uid),
			(e, c) => ((Ecs.Game.Components.UidComponent)c).Value));
	}
}

public static class ContextsExtensions
{
	public static GameEntity GetEntityWithConnectionId(this GameContext context, int Value)
	{
		return ((JCMG.EntitasRedux.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ConnectionId)).GetEntity(Value);
	}

	public static GameEntity GetEntityWithUid(this GameContext context, Ecs.Uid.Uid Value)
	{
		return ((JCMG.EntitasRedux.PrimaryEntityIndex<GameEntity, Ecs.Uid.Uid>)context.GetEntityIndex(Contexts.Uid)).GetEntity(Value);
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
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

	[JCMG.EntitasRedux.PostConstructor]
	public void InitializeContextObservers() {
		try {
			CreateContextObserver(Action);
			CreateContextObserver(Game);
			CreateContextObserver(Input);
		} catch(System.Exception) {
		}
	}

	public void CreateContextObserver(JCMG.EntitasRedux.IContext context) {
		if (UnityEngine.Application.isPlaying) {
			var observer = new JCMG.EntitasRedux.VisualDebugging.ContextObserver(context);
			UnityEngine.Object.DontDestroyOnLoad(observer.GameObject);
		}
	}

#endif
}
