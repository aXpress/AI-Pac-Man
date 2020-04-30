using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;

public class PacmanMovement : MonoBehaviour {
    public float speed = 4.0f;
    Vector3 dest = Vector2.zero;
    Vector3 originalPos;
    
    int lives = 3;

    void Start() {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    

    void Update() {
        checkInput();
        Move();
    }


    void checkInput(){
        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            dest = Vector3.up;
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            dest = Vector3.right;
        if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down))
            dest = Vector3.down;
        if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left))
            dest = Vector3.left;
    }


    bool valid(Vector3 direction) {
        Vector3 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    void Move(){
        GetComponent<Animator>().SetFloat("DirX", dest.x);
        GetComponent<Animator>().SetFloat("DirY", dest.y);
        transform.localPosition += (Vector3)(dest * speed) * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D collision)
	{
        bool hit_ghost = false;
		if(collision.name == "blue_ghost_p")
            hit_ghost = true;
        if(collision.name == "pink_ghost_p")
            hit_ghost = true;
        if(collision.name == "red_ghost_p")
            hit_ghost = true;
        if(collision.name == "orange_ghost_p")
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
                SceneManager.LoadScene("resultsScene");
                return;
            }
            lives--;
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);
            gameObject.transform.position = originalPos;
            GetComponent<Animator>().SetFloat("DirX", dest.x);
            GetComponent<Animator>().SetFloat("DirY", dest.y);
            Thread.Sleep(milliseconds);
        }
	}
}