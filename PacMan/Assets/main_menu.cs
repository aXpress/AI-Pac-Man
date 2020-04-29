using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("pacmanScene");
    }

    public void QuitGame()
    {
        Debug.Log("Game successfully quit.");
        Application.Quit();
    }
}
