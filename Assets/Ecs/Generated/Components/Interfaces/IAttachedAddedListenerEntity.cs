//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IAttachedAddedListenerEntity
{
	AttachedAddedListenerComponent AttachedAddedListener { get; }
	bool HasAttachedAddedListener { get; }

	void AddAttachedAddedListener(System.Collections.Generic.List<IAttachedAddedListener> newValue);
	void ReplaceAttachedAddedListener(System.Collections.Generic.List<IAttachedAddedListener> newValue);
	void RemoveAttachedAddedListener();
}
