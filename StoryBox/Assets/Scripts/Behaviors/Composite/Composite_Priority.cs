using UnityEngine;

public class Composite_Priority : Behavior {

	public Behavior[] behaviors;

	public override void Init() {
		foreach (Behavior b in behaviors) {
			b.Init();
		}
	}

	/// <summary>
	/// performs behavior
	/// </summary>
	/// <returns>behavior return code</returns>
	public override NodeStatus Act(Entity entity, Memory memory) {
		int i = entity.currentNodes.Count == 0 ? 0 : entity.currentNodes.Pop();
		NodeStatus status = NodeStatus.Failure;
		while (i < behaviors.Length) {
			// Run the current sub-behavior
			status = behaviors[i].Act(entity, memory);
			// Fails => continue to next one
			if (status == NodeStatus.Failure) {
				i++;
			}
			// Succeeds => break with status SUCCESS
			else if (status == NodeStatus.Success) {
				i = 0;
				break;
			}
			// Running => break with status RUNNING
			else if (status == NodeStatus.Running) {
				break;
			}
		}
		// If all sub-behaviors failed
		if (i == behaviors.Length)
			i = 0;
		entity.currentNodes.Push(i);
		return status;
	}
}