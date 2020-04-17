using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMovement : MonoBehaviour {
	public Transform [] checkpoints;
	private int cur = 0;
	public float ghostSpeed = .01f;

	void FixedUpdate () 
	{
		if(transform.position != checkpoints[cur].position)
		{
			Vector2 pos = Vector2.MoveTowards(transform.position, checkpoints[cur].position, ghostSpeed);
			GetComponent<Rigidbody2D>().MovePosition(pos);
		}
		else 
		{
			cur = cur + 1 % (checkpoints.Length);
		}
	}
}
