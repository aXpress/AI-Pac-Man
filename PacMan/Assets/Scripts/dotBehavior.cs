using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dotBehavior : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "pacman_sprite_p" || collision.gameObject.name == "pacman_sprite_ai")
			Destroy(this.gameObject);
			playerScore.score_val++;
	}
}
