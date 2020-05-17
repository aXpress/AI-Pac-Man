using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class playerScore : MonoBehaviour {

	public static int score_val;
	public static int dots;
	TextMeshPro score_text;
    private scoreManager scoreMgr;

    void Awake()
    {
        scoreMgr = GameObject.FindObjectOfType<scoreManager>();
    }

    void Start () {
		score_text = GetComponent<TextMeshPro>();
		score_val = 0;
		dots = 141;
	}
	
	void Update () {
		score_text.text = "SCORE: " + score_val;
        scoreMgr.UpdatePLScore(score_val);
	}
}
