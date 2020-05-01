using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class dotBehavior : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
          if (collision.gameObject.name == "pacman_sprite_p")
          {
               playerScore.scoreValue += 1;
               Destroy(this.gameObject);
          }

          if (collision.gameObject.name == "pacman_sprite_ai")
          {
               ai_Score.scoreValue += 1;
               Destroy(this.gameObject);
          }

     }
}
