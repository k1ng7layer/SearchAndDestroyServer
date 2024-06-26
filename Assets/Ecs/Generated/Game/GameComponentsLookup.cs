//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;

public static class GameComponentsLookup
{
	public const int AiAddedListener = 0;
	public const int AiRemovedListener = 1;
	public const int AttachedAddedListener = 2;
	public const int AttachedRemovedListener = 3;
	public const int DestinationAddedListener = 4;
	public const int DestinationRemovedListener = 5;
	public const int Ai = 6;
	public const int Attached = 7;
	public const int ConnectionId = 8;
	public const int ControlState = 9;
	public const int Destination = 10;
	public const int Destroyed = 11;
	public const int GameCountdown = 12;
	public const int GameState = 13;
	public const int Gunner = 14;
	public const int Infected = 15;
	public const int Input = 16;
	public const int InputRotation = 17;
	public const int Instantiate = 18;
	public const int Link = 19;
	public const int MoveDirection = 20;
	public const int NetworkId = 21;
	public const int Npc = 22;
	public const int Owner = 23;
	public const int Parasite = 24;
	public const int Player = 25;
	public const int Position = 26;
	public const int Prefab = 27;
	public const int Rotation = 28;
	public const int RotationVelocity = 29;
	public const int Target = 30;
	public const int Timer = 31;
	public const int Transform = 32;
	public const int Uid = 33;
	public const int GameCountdownAddedListener = 34;
	public const int InputAddedListener = 35;
	public const int InstantiateAddedListener = 36;
	public const int LinkRemovedListener = 37;
	public const int MoveDirectionAddedListener = 38;
	public const int PositionAddedListener = 39;
	public const int RotationAddedListener = 40;

	public const int TotalComponents = 41;

	public static readonly string[] ComponentNames =
	{
		"AiAddedListener",
		"AiRemovedListener",
		"AttachedAddedListener",
		"AttachedRemovedListener",
		"DestinationAddedListener",
		"DestinationRemovedListener",
		"Ai",
		"Attached",
		"ConnectionId",
		"ControlState",
		"Destination",
		"Destroyed",
		"GameCountdown",
		"GameState",
		"Gunner",
		"Infected",
		"Input",
		"InputRotation",
		"Instantiate",
		"Link",
		"MoveDirection",
		"NetworkId",
		"Npc",
		"Owner",
		"Parasite",
		"Player",
		"Position",
		"Prefab",
		"Rotation",
		"RotationVelocity",
		"Target",
		"Timer",
		"Transform",
		"Uid",
		"GameCountdownAddedListener",
		"InputAddedListener",
		"InstantiateAddedListener",
		"LinkRemovedListener",
		"MoveDirectionAddedListener",
		"PositionAddedListener",
		"RotationAddedListener"
	};

	public static readonly System.Type[] ComponentTypes =
	{
		typeof(AiAddedListenerComponent),
		typeof(AiRemovedListenerComponent),
		typeof(AttachedAddedListenerComponent),
		typeof(AttachedRemovedListenerComponent),
		typeof(DestinationAddedListenerComponent),
		typeof(DestinationRemovedListenerComponent),
		typeof(Ecs.Game.Components.AiComponent),
		typeof(Ecs.Game.Components.AttachedComponent),
		typeof(Ecs.Game.Components.ConnectionIdComponent),
		typeof(Ecs.Game.Components.ControlStateComponent),
		typeof(Ecs.Game.Components.DestinationComponent),
		typeof(Ecs.Game.Components.DestroyedComponent),
		typeof(Ecs.Game.Components.GameCountdownComponent),
		typeof(Ecs.Game.Components.GameStateComponent),
		typeof(Ecs.Game.Components.GunnerComponent),
		typeof(Ecs.Game.Components.InfectedComponent),
		typeof(Ecs.Game.Components.InputComponent),
		typeof(Ecs.Game.Components.InputRotationComponent),
		typeof(Ecs.Game.Components.InstantiateComponent),
		typeof(Ecs.Game.Components.LinkComponent),
		typeof(Ecs.Game.Components.MoveDirectionComponent),
		typeof(Ecs.Game.Components.NetworkIdComponent),
		typeof(Ecs.Game.Components.NpcComponent),
		typeof(Ecs.Game.Components.OwnerComponent),
		typeof(Ecs.Game.Components.ParasiteComponent),
		typeof(Ecs.Game.Components.PlayerComponent),
		typeof(Ecs.Game.Components.PositionComponent),
		typeof(Ecs.Game.Components.PrefabComponent),
		typeof(Ecs.Game.Components.RotationComponent),
		typeof(Ecs.Game.Components.RotationVelocityComponent),
		typeof(Ecs.Game.Components.TargetComponent),
		typeof(Ecs.Game.Components.TimerComponent),
		typeof(Ecs.Game.Components.TransformComponent),
		typeof(Ecs.Game.Components.UidComponent),
		typeof(GameCountdownAddedListenerComponent),
		typeof(InputAddedListenerComponent),
		typeof(InstantiateAddedListenerComponent),
		typeof(LinkRemovedListenerComponent),
		typeof(MoveDirectionAddedListenerComponent),
		typeof(PositionAddedListenerComponent),
		typeof(RotationAddedListenerComponent)
	};

	public static readonly Dictionary<Type, int> ComponentTypeToIndex = new Dictionary<Type, int>
	{
		{ typeof(AiAddedListenerComponent), 0 },
		{ typeof(AiRemovedListenerComponent), 1 },
		{ typeof(AttachedAddedListenerComponent), 2 },
		{ typeof(AttachedRemovedListenerComponent), 3 },
		{ typeof(DestinationAddedListenerComponent), 4 },
		{ typeof(DestinationRemovedListenerComponent), 5 },
		{ typeof(Ecs.Game.Components.AiComponent), 6 },
		{ typeof(Ecs.Game.Components.AttachedComponent), 7 },
		{ typeof(Ecs.Game.Components.ConnectionIdComponent), 8 },
		{ typeof(Ecs.Game.Components.ControlStateComponent), 9 },
		{ typeof(Ecs.Game.Components.DestinationComponent), 10 },
		{ typeof(Ecs.Game.Components.DestroyedComponent), 11 },
		{ typeof(Ecs.Game.Components.GameCountdownComponent), 12 },
		{ typeof(Ecs.Game.Components.GameStateComponent), 13 },
		{ typeof(Ecs.Game.Components.GunnerComponent), 14 },
		{ typeof(Ecs.Game.Components.InfectedComponent), 15 },
		{ typeof(Ecs.Game.Components.InputComponent), 16 },
		{ typeof(Ecs.Game.Components.InputRotationComponent), 17 },
		{ typeof(Ecs.Game.Components.InstantiateComponent), 18 },
		{ typeof(Ecs.Game.Components.LinkComponent), 19 },
		{ typeof(Ecs.Game.Components.MoveDirectionComponent), 20 },
		{ typeof(Ecs.Game.Components.NetworkIdComponent), 21 },
		{ typeof(Ecs.Game.Components.NpcComponent), 22 },
		{ typeof(Ecs.Game.Components.OwnerComponent), 23 },
		{ typeof(Ecs.Game.Components.ParasiteComponent), 24 },
		{ typeof(Ecs.Game.Components.PlayerComponent), 25 },
		{ typeof(Ecs.Game.Components.PositionComponent), 26 },
		{ typeof(Ecs.Game.Components.PrefabComponent), 27 },
		{ typeof(Ecs.Game.Components.RotationComponent), 28 },
		{ typeof(Ecs.Game.Components.RotationVelocityComponent), 29 },
		{ typeof(Ecs.Game.Components.TargetComponent), 30 },
		{ typeof(Ecs.Game.Components.TimerComponent), 31 },
		{ typeof(Ecs.Game.Components.TransformComponent), 32 },
		{ typeof(Ecs.Game.Components.UidComponent), 33 },
		{ typeof(GameCountdownAddedListenerComponent), 34 },
		{ typeof(InputAddedListenerComponent), 35 },
		{ typeof(InstantiateAddedListenerComponent), 36 },
		{ typeof(LinkRemovedListenerComponent), 37 },
		{ typeof(MoveDirectionAddedListenerComponent), 38 },
		{ typeof(PositionAddedListenerComponent), 39 },
		{ typeof(RotationAddedListenerComponent), 40 }
	};

	/// <summary>
	/// Returns a component index based on the passed <paramref name="component"/> type; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="component"></param>
	public static int GetComponentIndex(IComponent component)
	{
		return GetComponentIndex(component.GetType());
	}

	/// <summary>
	/// Returns a component index based on the passed <paramref name="componentType"/>; where an index cannot be found
	/// -1 will be returned instead.
	/// </summary>
	/// <param name="componentType"></param>
	public static int GetComponentIndex(Type componentType)
	{
		return ComponentTypeToIndex.TryGetValue(componentType, out var index) ? index : -1;
	}
}
