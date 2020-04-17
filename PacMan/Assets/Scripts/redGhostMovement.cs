using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redGhostMovement : MonoBehaviour {

	public Rigidbody2D ghostRB;
	public float ghostSpeed;
	private Vector2 ghostMovement;

	// Set speed and set ghost component
	void Start () 
	{
		ghostSpeed = 200f;
		ghostRB = GetComponent<Rigidbody2D>();
	}

	// Change movement of ghost
	void FixedUpdate () 
	{
		updateDirection(ref ghostMovement);
		ghostRB.velocity = ghostMovement * ghostSpeed * Time.deltaTime;
	}

	// Get new direction for ghost
	void updateDirection(ref Vector2 ghostDirection)
	{
		int x = 0;
		int y = 0;
		int direction = Random.Range(0, 2);

		// If direction is 0, the ghost will move vertically
		if(direction == 0)
		{
			y = Random.Range(0, 2);
			if(y == 0)
			{
				y = -1;
			}
			ghostDirection = new Vector2(x, y);
		}
		// Otherwise, the ghost will move horizontally
		else
		{
			x = Random.Range(0, 2);
			if (x == 0)
			{
				x = -1;
			}
			ghostDirection = new Vector2(x, y);
		}
	}
}
