using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class AILives : MonoBehaviour {
	int lives = 3;
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
        if(hit_ghost == true){
            if(lives == 3){
                Destroy (GameObject.FindWithTag("ai_life_three"));
            }
            else if(lives == 2){
                Destroy (GameObject.FindWithTag("ai_life_two"));
            }
            else if(lives == 1){
                Destroy (GameObject.FindWithTag("ai_life_one"));
            }
            lives--;
            int milliseconds = 500;
            Thread.Sleep(milliseconds);
            //Debug.Log(lives);
        }
	}
}
