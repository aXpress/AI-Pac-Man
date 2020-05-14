using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerTracker : MonoBehaviour {

	public Text timerText;
	public float secondsAllowed;
	float startTime;
    static float timeTaken;
    private scoreManager scoreMgr;

    void Awake() {
        scoreMgr = GameObject.FindObjectOfType<scoreManager>();
    }

    // Use this for initialization
    void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		timeTaken = (Time.time - startTime);
		
		string timeTakenStr = timeTaken.ToString("f1");
		timerText.text = timeTakenStr;

        scoreMgr.UpdateTime(timeTaken);
	}
}
