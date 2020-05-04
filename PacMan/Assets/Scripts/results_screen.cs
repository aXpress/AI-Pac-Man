using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class results_screen : MonoBehaviour {

    private scoreManager scoreMgr;

    void Awake() {
        scoreMgr = GameObject.FindObjectOfType<scoreManager>();
        //scoreMgr.UpdateAIScore(0);
        //scoreMgr.UpdatePLScore(0);
        //scoreMgr.UpdateTime(0);
    }

    public void PlayAgain() {
        scoreMgr.UpdatePLScore(0);
        scoreMgr.UpdateAIScore(0);
        scoreMgr.UpdateTime(0);
        SceneManager.LoadScene("pacmanScene");
    }

    public void GoToMain() {
        scoreMgr.UpdatePLScore(0);
        scoreMgr.UpdateAIScore(0);
        scoreMgr.UpdateTime(0);
        SceneManager.LoadScene("menuScene");
    }
}
