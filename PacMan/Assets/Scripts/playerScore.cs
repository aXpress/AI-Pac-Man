using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class playerScore : MonoBehaviour {

	public static int score_val;
	public Text score_text;
	// Use this for initialization
	void Start () {
		score_text = GetComponent<Text>();
		score_val = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score_text.text = "" + score_val;

	}
}
