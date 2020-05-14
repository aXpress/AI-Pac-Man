using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;



public class AILives : MonoBehaviour {
	int lives = 3;
    Vector3 originalPos;
    
    void Start() {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    

    void OnTriggerEnter2D(Collider2D collision)
	{
        bool hit_ghost = false;
		if(collision.name == "blue_ghost_ai")
            hit_ghost = true;
        if(collision.name == "pink_ghost_ai")
            hit_ghost = true;
        if(collision.name == "red_ghost_ai")
            hit_ghost = true;
        if(collision.name == "orange_ghost_ai")
            hit_ghost = true;
        if(hit_ghost == true)
            AI_collidedWithGhost();
	}

    void AI_collidedWithGhost()
    {
        if(lives == 3)
            Destroy (GameObject.FindWithTag("life_three_ai"));
        else if(lives == 2)
            Destroy (GameObject.FindWithTag("life_two_ai"));
        else if(lives == 1)
        {
            Destroy (GameObject.FindWithTag("life_one_ai"));
            SceneManager.LoadScene("resultsScene");
            return;
        }
        lives--;
        int milliseconds = 1000;
        Thread.Sleep(milliseconds);
        gameObject.transform.position = originalPos;
        //GetComponent<Animator>().SetFloat("DirX", dest.x);
        //GetComponent<Animator>().SetFloat("DirY", dest.y);
        Thread.Sleep(milliseconds);
    }
}