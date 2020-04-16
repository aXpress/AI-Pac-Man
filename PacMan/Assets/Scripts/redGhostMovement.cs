using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redGhostMovement : MonoBehaviour {

	public float ghostSpeed = 0.30f;

	public Rigidbody ghostRB;

	private int moveX = -1;
	private int moveY = 0;

	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		// If there is a collision or intersection...
		changeDirection(ref moveX, ref moveY);
	}

	void changeDirection(ref int x, ref int y)
	{
		int direction = Random.Range(1, 4);
		
		// Move left
		if (direction == 1)
		{
			x = -1;
			y = 0;
		}
		// Move right
		else if (direction == 2)
		{
			x = 1;
			y = 0;
		}
		// Move down
		else if (direction == 3)
		{
			x = 0;
			y = -1;
		}
		// Move up
		else
		{
			x = 0;
			y = 1;
		}
	}
}
