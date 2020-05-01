using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ai_Score : MonoBehaviour
{

     public static int scoreValue = 0;
     TextMeshPro score;

     // Use this for initialization
     void Start()
     {
          score = GetComponent<TextMeshPro>();
     }

     // Update is called once per frame
     void Update()
     {
          score.text = "SCORE: " + scoreValue;

     }
}
