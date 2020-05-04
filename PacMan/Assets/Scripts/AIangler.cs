using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIangler : MonoBehaviour {

	private Vector3 tempPos;
	public Transform playerTransform;

	// Use this for initialization
	void Start () {
		playerTransform = this.GetComponent<Transform>();
		tempPos = playerTransform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Animator>().SetFloat("DirX", (playerTransform.position - tempPos).x);
        GetComponent<Animator>().SetFloat("DirY", (playerTransform.position - tempPos).y);
		tempPos = playerTransform.position;
	}
}
