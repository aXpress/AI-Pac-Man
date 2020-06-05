using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class dotBehavior : MonoBehaviour {

    public AudioSource waka;

    private void Start()
    {
        //waka = GameObject.FindGameObjectWithTag("Audio Source - waka").GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
        waka.Play();

          if (collision.gameObject.name == "pacman_sprite_p")
          {
               Destroy(this.gameObject);
               playerScore.score_val++;
               playerScore.dots--;
               
               if(playerScore.dots == 0){
                    SceneManager.LoadScene("resultsScene");
               }
          }

          if (collision.gameObject.name == "pacman_sprite_ai")
          {
               Destroy(this.gameObject);
               aiScore.score_val++;
               aiScore.ai_dots--;
               
               if(aiScore.ai_dots == 0){
                    SceneManager.LoadScene("resultsScene");
               }
          }
     }
}
