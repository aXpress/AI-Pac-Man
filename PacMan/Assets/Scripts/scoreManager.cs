using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    static float storedPLScore;
    static float storedAIScore;
    static float elapsedTime;

    public void UpdatePLScore(float playerScore)
    {
        storedPLScore = playerScore;
    }

    public void UpdateAIScore(float aiScore)
    {
        storedAIScore = aiScore;
    }

    public void UpdateTime(float finalTime)
    {
        elapsedTime = finalTime;
    }

    public float getPlayerScore()
    {
        return storedPLScore;
    }

    public float getAIScore()
    {
        return storedAIScore;
    }

    public float getTime()
    {
        return elapsedTime;
    }
}
