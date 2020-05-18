using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMovement : MonoBehaviour {

	private bool active = false;
	public int waitTime;


	public float ghostSpeed;
	public Vector3 startPosition;
	public Transform [] checkpoints;
	private int cur = 0;

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
