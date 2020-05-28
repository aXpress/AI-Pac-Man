using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Simple patrol behavior.
	/// This will set the destination on the agent so that it moves through the sequence of objects in the <see cref="targets"/> array.
	/// Upon reaching a target it will wait for <see cref="delay"/> seconds.
	///
	/// See: <see cref="Pathfinding.AIDestinationSetter"/>
	/// See: <see cref="Pathfinding.AIPath"/>
	/// See: <see cref="Pathfinding.RichAI"/>
	/// See: <see cref="Pathfinding.AILerp"/>
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_patrol.php")]
	public class Patrol : VersionedMonoBehaviour {
		/// <summary>Target points to move to in order</summary>
		public Transform[] targets;

		/// <summary>Time in seconds to wait at each target</summary>
		public float delay = 0;

		public int type; //0 is a ghost, 1 is a pacman

		/// <summary>Current target index</summary>
		int index;

		IAstarAI agent;
		float switchTime = float.PositiveInfinity;

		protected override void Awake () {
			base.Awake();
			agent = GetComponent<IAstarAI>();

			index = Random.Range(0, targets.Length);
			agent.destination = targets[index].position;
		}

		/// <summary>Update is called once per frame</summary>
		void Update () {
			if (targets.Length == 0) return;

			bool search = false;

			// Note: using reachedEndOfPath and pathPending instead of reachedDestination here because
			// if the destination cannot be reached by the agent, we don't want it to get stuck, we just want it to get as close as possible and then move on.
			if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) {
				switchTime = Time.time + delay;
			}

			if (Time.time >= switchTime) {
				index = index + 1;
				search = true;
				switchTime = float.PositiveInfinity;
			}

			index = index % targets.Length;

               // Loop to find the closest dot and set destination to it
			if(type == 1)
			{
				if (targets[index])
				{
					float distanceToClosestDot = Mathf.Infinity;
					Transform closestDot = null;

					foreach (Transform currentDot in targets)
					{
						if (currentDot)
						{
							float distanceToDot = (currentDot.transform.position - this.transform.position).sqrMagnitude;
							if (distanceToDot < distanceToClosestDot)
							{
								distanceToClosestDot = distanceToDot;
								closestDot = currentDot;
								agent.destination = closestDot.position;
							}
						}
					}
						
				} 
			}
			else if(type == 0 && Vector2.Distance(gameObject.transform.position, agent.destination) < 1)
			{
				index = Random.Range(0, targets.Length);
				agent.destination = targets[index].position;
				// Debug.Log("currently pursuing checkpoint " + targets[index].name); 
				// index = (index + 1) % targets.Length;

			}

			if (search) agent.SearchPath();
		}
	}
}
