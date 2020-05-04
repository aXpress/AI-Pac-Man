using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerResults : MonoBehaviour {

    public Text pScore;
    private scoreManager scoreMgr;

    void Awake()
    {
        scoreMgr = GameObject.FindObjectOfType<scoreManager>();
    }

    void Start()
    {
        string pScoreStr = scoreMgr.getPlayerScore().ToString("f1");
        pScore.text = pScoreStr;
    }
}
