using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// SOURCE: https://noobtuts.com/unity/2d-pacman-game

public class ghostMovement : MonoBehaviour {

	public bool active = false;
	//public int cur = 0;
	public Vector3 startPosition;
	public float waitTime;
	public float ghostSpeed;
	// public Transform [] checkpoints;
	public Transform startTransform;
	private bool firstMove;
	private bool moveToCurTarget;
	private Transform curTarget;

	void Start ()
	{
		startPosition = gameObject.transform.position;
		firstMove = true;
	}

	void FixedUpdate ()
	{
		if (!active && (Time.timeSinceLevelLoad >= waitTime))
		{
			active = true;
		}
		
		if (active)//only move if this is the script that should control the motion
		{
			// Ghost continues moving to destination/checkpoint
			// if (transform.position != checkpoints[cur].position)
			// {
			// 	Vector2 pos = Vector2.MoveTowards(transform.position, checkpoints[cur].position, ghostSpeed);
			// 	GetComponent<Rigidbody2D>().MovePosition(pos);
			// }
			// // Ghost has reached destination and will move to next destination/checkpoint
			// else
			// {
			// 	cur = (cur + 1) % checkpoints.Length;
			// }

			if(firstMove)
				doFirstMove();

			if(moveToCurTarget)
			{
				moveToSpot(curTarget);
				if(transform.position == curTarget.position)
				{
					chooseDirection(curTarget);
					moveToCurTarget = false;
				}
			}
				
		}
	
	}


	void ghostWaitTime(int stdWaitTime)
	{
		waitTime = stdWaitTime + Time.timeSinceLevelLoad;
	}


	public void ghostRespawn(string name)
	{
		gameObject.transform.position = startPosition;
		//cur = 0;

		if (name == "pink_ghost_p")
			ghostWaitTime(3);
		else if (name == "blue_ghost_p")
			ghostWaitTime(5);
		else if (name == "orange_ghost_p")
			ghostWaitTime(7);

		active = false;
		firstMove = true;
	}


	void doFirstMove()
	{

		moveToSpot(startTransform);

		if(transform.position == startTransform.position)
		{
			firstMove = false;
			if(Random.Range(0,2) == 1)
				GetComponent<Rigidbody2D>().velocity = Vector2.left * ghostSpeed;
			else
				GetComponent<Rigidbody2D>().velocity = Vector2.right * ghostSpeed;
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		moveToCurTarget = true;
		curTarget = col.gameObject.GetComponent<Transform>();
	}


	private void moveToSpot(Transform target)
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		Vector2 pos = Vector2.MoveTowards(transform.position, target.position, 0.1f);
		rb.MovePosition(pos);
	}


	private void chooseDirection(Transform col)
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if(col.GetComponent<Collider2D>().tag == "checkpoint")
		{

			rb.velocity = Vector2.zero;

			//Debug.Log("collided with checkpoint");
			bool [] directions = {false, false, false, false};
			directions[0] = col.gameObject.GetComponent<checkpointScr>().up;
			directions[1] = col.gameObject.GetComponent<checkpointScr>().down;
			directions[2] = col.gameObject.GetComponent<checkpointScr>().left;
			directions[3] = col.gameObject.GetComponent<checkpointScr>().right;

			int direc = Random.Range(0,4);
			while(!directions[direc])
				direc = Random.Range(0,4);

			switch(direc)
			{
				case 0: // move up
					rb.velocity = Vector2.up * ghostSpeed;
					break;
				case 1: // move down
					rb.velocity = Vector2.down * ghostSpeed;
					break;
				case 2: // move left
					rb.velocity = Vector2.left * ghostSpeed;
					break;
				case 3: // move right
					rb.velocity = Vector2.right * ghostSpeed;
					break;
			}
		}
	}


}
