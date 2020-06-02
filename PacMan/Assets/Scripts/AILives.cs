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
        else if(collision.name == "pink_ghost_ai")
            hit_ghost = true;
        else if(collision.name == "red_ghost_ai")
            hit_ghost = true;
        else if(collision.name == "orange_ghost_ai")
            hit_ghost = true;

        if (hit_ghost == true)
        {
            respawnAIGhosts();
            respawnAIPacMan(true);

            PacmanMovement player = GameObject.Find("pacman_sprite_p").GetComponent<PacmanMovement>();
            player.respawnPacMan(false);
        }
	}

    void respawnAIGhosts()
    {
        ghostMovement redGhostScript = GameObject.Find("red_ghost_p").GetComponent<ghostMovement>();
        redGhostScript.ghostRespawn("red_ghost_p");

        ghostMovement pinkGhostScript = GameObject.Find("pink_ghost_p").GetComponent<ghostMovement>();
        pinkGhostScript.ghostRespawn("pink_ghost_p");

        ghostMovement blueGhostScript = GameObject.Find("blue_ghost_p").GetComponent<ghostMovement>();
        blueGhostScript.ghostRespawn("blue_ghost_p");

        ghostMovement orangeGhostScript = GameObject.Find("orange_ghost_p").GetComponent<ghostMovement>();
        orangeGhostScript.ghostRespawn("orange_ghost_p");
    }


    public void respawnAIPacMan(bool calledHere)
    {
        if(calledHere)
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
        }
        gameObject.transform.position = originalPos;
        //GetComponent<Animator>().SetFloat("DirX", dest.x);
        //GetComponent<Animator>().SetFloat("DirY", dest.y);
    }
}