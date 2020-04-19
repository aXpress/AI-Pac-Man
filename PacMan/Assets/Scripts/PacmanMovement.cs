﻿using UnityEngine;
using System.Collections;

public class PacmanMovement : MonoBehaviour {
    public float speed = 4.0f;
    Vector2 dest = Vector2.zero;
    
    int lives = 3;

    void Start() {
        //dest = transform.position;
    }

    void Update() {
        checkInput();
        Move();
    }
    void checkInput(){
        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            dest = Vector2.up;
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            dest = Vector2.right;
        if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down))
            dest = Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left))
            dest = Vector2.left;
    }
    bool valid(Vector2 direction) {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    void Move(){
        GetComponent<Animator>().SetFloat("DirX", dest.x);
        GetComponent<Animator>().SetFloat("DirY", dest.y);
        transform.localPosition += (Vector3)(dest * speed) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
        bool hit_ghost = false;
		if(collision.gameObject.name == "blue_ghost")
            hit_ghost = true;
        if(collision.gameObject.name == "pink_ghost")
            hit_ghost = true;
        if(collision.gameObject.name == "red_ghost")
            hit_ghost = true;
        if(collision.gameObject.name == "orange_ghost")
            hit_ghost = true;
        if(hit_ghost == true){
            if(lives == 3){
                Destroy (GameObject.FindWithTag("life_three"));
            }
            else if(lives == 2){
                Destroy (GameObject.FindWithTag("life_two"));
            }
            else if(lives == 1){
                Destroy (GameObject.FindWithTag("life_one"));
            }
            lives--;
            //Debug.Log(lives);
        }
	}
}