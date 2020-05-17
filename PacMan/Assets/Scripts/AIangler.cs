using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIangler : MonoBehaviour {

	private Vector3 tempPos;
	public Transform AIPacmanTransform;


	void Start () {
		AIPacmanTransform = this.GetComponent<Transform>();
		tempPos = AIPacmanTransform.position;
	}
	

	void FixedUpdate () {
		GetComponent<Animator>().SetFloat("DirX", (AIPacmanTransform.position - tempPos).x);
        GetComponent<Animator>().SetFloat("DirY", (AIPacmanTransform.position - tempPos).y);
		tempPos = AIPacmanTransform.position;
	}
}
