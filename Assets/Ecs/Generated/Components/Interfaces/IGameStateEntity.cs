//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IGameStateEntity
{
	Ecs.Game.Components.GameStateComponent GameState { get; }
	bool HasGameState { get; }

	void AddGameState(Utils.EGameState newValue);
	void ReplaceGameState(Utils.EGameState newValue);
	void RemoveGameState();
}