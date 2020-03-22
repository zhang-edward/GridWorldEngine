using System.Collections.Generic;
using UnityEngine;

public class Leaf_CreateEntityHere : Behavior {

	public EntityData data;

	[Header("Write Keys")]
	public string childEntitiesKey = "children";
	public string childKey = "child";

	public override NodeStatus Act(Entity entity, Memory memory) {
		if (memory[childEntitiesKey] == null)
			memory[childEntitiesKey] = new List<Entity>();

		Entity child = EntityManager.instance.CreateEntity(data, entity.position.x, entity.position.y, entity.faction);
		if (child != null) {
			(memory[childEntitiesKey] as List<Entity>).Add(child);
			memory[childKey] = child;
			return NodeStatus.Success;
		}
		return NodeStatus.Failure;
	}
}