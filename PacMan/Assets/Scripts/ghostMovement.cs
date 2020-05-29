using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// SOURCE: https://noobtuts.com/unity/2d-pacman-game

public class ghostMovement : MonoBehaviour {

	public bool active = false;
	public int cur = 0;
	public Vector3 startPosition;
	public float waitTime;
	public float ghostSpeed;
	public Transform [] checkpoints;
	public bool ghostAI;
	public bool firstStep;

	void Start ()
	{
		startPosition = gameObject.transform.position;
	}

	void FixedUpdate ()
	{
		if (!active && (Time.timeSinceLevelLoad >= waitTime))
		{
			active = true;
		}
		
		if (active && (ghostAI || firstStep))//only move if this is the script that should control the motion
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

			if(!ghostAI && cur > 0)
				firstStep = false;
		}
		else if(!active && (ghostAI || firstStep))
		{
			Vector2 pos = Vector2.MoveTowards(transform.position, transform.position, ghostSpeed);//cheap trick to make the ghost stay still
			GetComponent<Rigidbody2D>().MovePosition(pos);
		}
		
	}


	void ghostWaitTime(int stdWaitTime)
	{
		waitTime = stdWaitTime + Time.timeSinceLevelLoad;
		active = false;
	}


	public void ghostRespawn(string name)
	{
		gameObject.transform.position = startPosition;
		cur = 0;

		if (name == "pink_ghost_p")
			ghostWaitTime(3);
		else if (name == "blue_ghost_p")
			ghostWaitTime(5);
		else if (name == "orange_ghost_p")
			ghostWaitTime(7);
	}
}
