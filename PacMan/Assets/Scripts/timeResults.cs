using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeResults : MonoBehaviour {

    public Text finalTime;
    private scoreManager scoreMgr;

    void Awake()
    {
        scoreMgr = GameObject.FindObjectOfType<scoreManager>();
    }

    void Start()
    {
        string fTimeStr = scoreMgr.getTime().ToString("f1");
        finalTime.text = fTimeStr;
    }
}
