using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class aiResults : MonoBehaviour {

    public Text aiScore;
    private scoreManager scoreMgr;

    void Awake()
    {
        scoreMgr = GameObject.FindObjectOfType<scoreManager>();
    }

    void Start()
    {
        string aiScoreStr = scoreMgr.getAIScore().ToString("f1");
        aiScore.text = aiScoreStr;
    }
}
