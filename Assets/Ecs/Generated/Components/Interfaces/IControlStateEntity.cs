//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IControlStateEntity
{
	Ecs.Game.Components.ControlStateComponent ControlState { get; }
	bool HasControlState { get; }

	void AddControlState(bool newEnabled);
	void ReplaceControlState(bool newEnabled);
	void RemoveControlState();
}