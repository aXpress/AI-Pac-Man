using System.Collections;
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
		//secondsAllowed = 60;
	}
	
	// Update is called once per frame
	void Update () {
		float timeLeft = secondsAllowed - (Time.time - startTime);
		if(timeLeft == 0)
		{
			SceneManager.LoadScene("resultsScene");
			return;
		}
		string timeLeftStr = timeLeft.ToString("f2");
		timerText.text = timeLeftStr;
	}
}
