//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IAiAddedListenerEntity
{
	AiAddedListenerComponent AiAddedListener { get; }
	bool HasAiAddedListener { get; }

	void AddAiAddedListener(System.Collections.Generic.List<IAiAddedListener> newValue);
	void ReplaceAiAddedListener(System.Collections.Generic.List<IAiAddedListener> newValue);
	void RemoveAiAddedListener();
}
