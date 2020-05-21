using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ghostMovement : MonoBehaviour {

	public bool active = false;
	public int cur = 0;
	public Vector3 startPosition;
	public float waitTime;
	public float ghostSpeed;
	public Transform [] checkpoints;


	void Start ()
	{
		startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	}

	void FixedUpdate () 
	{
		if (!active && (Time.timeSinceLevelLoad >= waitTime))
		{
			active = true;
		}
		
		if (active)
		{
			// Ghost continues moving to destination/checkpoint
			if (transform.position != checkpoints[cur].position)
			{
				Vector2 pos = Vector2.MoveTowards(transform.position, checkpoints[cur].position, ghostSpeed);
				GetComponent<Rigidbody2D>().MovePosition(pos);
			}
			// Ghost has reached destination and will move to next destination/checkpoint
			else
			{
				cur = (cur + 1) % checkpoints.Length;
			}
		}
		
	}
}
