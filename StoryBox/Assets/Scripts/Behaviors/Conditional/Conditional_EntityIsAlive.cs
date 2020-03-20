using UnityEngine;

public class Conditional_EntityIsAlive : Behavior {

	[Header("Read Keys")]
	[Tooltip("Entity")]
	public string targetKey = "target";

	public override NodeStatus Act() {
		Entity other = memory[targetKey] as Entity;
		if (other.health > 0)
			return NodeStatus.Success;
		else
			return NodeStatus.Failure;
	}
}