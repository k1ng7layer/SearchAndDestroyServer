//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature
{
	public GameEventSystems(Contexts contexts)
	{
		Add(new AiAddedEventSystem(contexts)); // priority: 0
		Add(new AiRemovedEventSystem(contexts)); // priority: 0
		Add(new AttachedAddedEventSystem(contexts)); // priority: 0
		Add(new AttachedRemovedEventSystem(contexts)); // priority: 0
		Add(new DestinationAddedEventSystem(contexts)); // priority: 0
		Add(new DestinationRemovedEventSystem(contexts)); // priority: 0
		Add(new GameCountdownAddedEventSystem(contexts)); // priority: 0
		Add(new InputAddedEventSystem(contexts)); // priority: 0
		Add(new InstantiateAddedEventSystem(contexts)); // priority: 0
		Add(new LinkRemovedEventSystem(contexts)); // priority: 0
		Add(new MoveDirectionAddedEventSystem(contexts)); // priority: 0
		Add(new PositionAddedEventSystem(contexts)); // priority: 0
		Add(new RotationAddedEventSystem(contexts)); // priority: 0
	}
}
