using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class results_screen : MonoBehaviour {

    public void PlayAgain()
    {
        SceneManager.LoadScene("pacmanScene");
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("menuScene");
    }
}
