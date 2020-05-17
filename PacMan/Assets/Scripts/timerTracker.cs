using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerTracker : MonoBehaviour {

	public Text timerText;
	float startTime;
    static float timeTaken;
    private scoreManager scoreMgr;

    void Awake() {
        scoreMgr = GameObject.FindObjectOfType<scoreManager>();
    }


    void Start () {
		startTime = Time.time;
	}
	

	void Update () {
		timeTaken = (Time.time - startTime);
		
		string timeTakenStr = timeTaken.ToString("f1");
		timerText.text = timeTakenStr;

        scoreMgr.UpdateTime(timeTaken);
	}
}
