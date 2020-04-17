using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotBehavior : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "pacman_sprite_0")
			Destroy(this.gameObject);
			// Debug.Log("collsion detected");
	}
}
