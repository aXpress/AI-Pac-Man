using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;
using System;

public class PacmanMovement : MonoBehaviour
{
    public float speed = 7.0f;
    Vector3 dest = Vector2.zero;
    Vector3 originalPos;
    public bool isPaused = false;

    int lives = 3;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }


    void Update()
    {
        if (isPaused && Input.anyKeyDown)
        {
            resumeGame();
        }

        checkInput();
        move();
    }


    void checkInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            dest = Vector3.up;
        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            dest = Vector3.right;
        if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down))
            dest = Vector3.down;
        if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left))
            dest = Vector3.left;
    }


    bool valid(Vector3 direction)
    {
        Vector3 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }


    void move()
    {
        GetComponent<Animator>().SetFloat("DirX", dest.x);
        GetComponent<Animator>().SetFloat("DirY", dest.y);
        transform.localPosition += (Vector3)(dest * speed) * Time.deltaTime;
    }


    void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }


    void resumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool hit_ghost = false;
        if (collision.name == "red_ghost_p")
            hit_ghost = true;
        else if (collision.name == "pink_ghost_p")
            hit_ghost = true;
        else if (collision.name == "blue_ghost_p")
            hit_ghost = true;
        else if (collision.name == "orange_ghost_p")
            hit_ghost = true;

        if (hit_ghost == true)
        {
            respawnPacMan();
            respawnGhosts();
        }
    }

    void respawnPacMan()
    {
        if (lives == 3)
            Destroy(GameObject.FindWithTag("life_three"));
        else if (lives == 2)
            Destroy(GameObject.FindWithTag("life_two"));
        else if (lives == 1)
        {
            Destroy(GameObject.FindWithTag("life_one"));
            SceneManager.LoadScene("resultsScene");
            return;
        }

        lives--;
        pauseGame();
        gameObject.transform.position = originalPos;
        GetComponent<Animator>().SetFloat("DirX", dest.x);
        GetComponent<Animator>().SetFloat("DirY", dest.y);
    }

    void respawnGhosts()
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
}