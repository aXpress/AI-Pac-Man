using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMovement : MonoBehaviour {
	// Ghost active variables
	private bool active = false;
	public int waitTime;
	public Transform waiting;

	// Ghost movement variables
	public float ghostSpeed;
	public Transform [] checkpoints;
	private int cur = 0;

	void FixedUpdate () 
	{
		if (!active && (Time.unscaledTime >= waitTime))
		{
			active = true;
		}
		
		if (active)
		{
			if (transform.position != checkpoints[cur].position)
			{
				Vector2 pos = Vector2.MoveTowards(transform.position, checkpoints[cur].position, ghostSpeed);
				GetComponent<Rigidbody2D>().MovePosition(pos);
			}
			else
			{
				cur = (cur + 1) % checkpoints.Length;
			}
		}
		
	}
}
