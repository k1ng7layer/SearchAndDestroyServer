//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IPrefabEntity
{
	Ecs.Game.Components.PrefabComponent Prefab { get; }
	bool HasPrefab { get; }

	void AddPrefab(string newName);
	void ReplacePrefab(string newName);
	void RemovePrefab();
}
