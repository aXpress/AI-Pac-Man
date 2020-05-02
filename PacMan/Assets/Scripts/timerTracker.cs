﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerTracker : MonoBehaviour {

	public Text timerText;
	public float secondsAllowed;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float timeTaken = (Time.time - startTime);
		// if(timeTaken <= 0)
		// {
		// 	SceneManager.LoadScene("resultsScene");
		// 	return;
		// }
		string timeTakenStr = timeTaken.ToString("f1");
		timerText.text = timeTakenStr;
	}
}
