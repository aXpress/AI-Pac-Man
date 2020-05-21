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
    Vector3 redGhostPos;
    Vector3 blueGhostPos;
    Vector3 pinkGhostPos;
    Vector3 orangeGhostPos;
    
    
    int lives = 3;

    void Start()
    {
        originalPos = gameObject.transform.position;
        redGhostPos = GameObject.Find("red_ghost_p").transform.position;
        blueGhostPos = GameObject.Find("blue_ghost_p").transform.position;
        pinkGhostPos = GameObject.Find("pink_ghost_p").transform.position;
        orangeGhostPos = GameObject.Find("orange_ghost_p").transform.position;
    }


    void Update()
    {
        if(isPaused && Input.anyKeyDown)
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


    void OnTriggerEnter2D(Collider2D collision)
    {
        bool hit_ghost = false;
        if (collision.name == "blue_ghost_p")
            hit_ghost = true;
        if (collision.name == "pink_ghost_p")
            hit_ghost = true;
        if (collision.name == "red_ghost_p")
            hit_ghost = true;
        if (collision.name == "orange_ghost_p")
            hit_ghost = true;
        if (hit_ghost == true)
        {
            collidedWithGhost();
        }
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


    void ghostWaitTime(ghostMovement script, int stdWaitTime)
    {
        script.waitTime = stdWaitTime + Time.time;
        script.active = false;
    }


    void ghostRespawn(string name, Vector3 respawnPoint)
    {
        GameObject ghost = GameObject.Find(name);
        ghost.transform.position = respawnPoint;

        ghostMovement ghostScript = ghost.GetComponent<ghostMovement>();
        ghostScript.cur = 0;

        if (name == "pink_ghost_p")
            ghostWaitTime(ghostScript, 3);
        else if (name == "blue_ghost_p")
            ghostWaitTime(ghostScript, 5);
        else if (name == "orange_ghost_p")
            ghostWaitTime(ghostScript, 7);
    }


    void collidedWithGhost()
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

        // Respawn Pac-Man
        gameObject.transform.position = originalPos;
        GetComponent<Animator>().SetFloat("DirX", dest.x);
        GetComponent<Animator>().SetFloat("DirY", dest.y);

        ghostRespawn("red_ghost_p", redGhostPos);
        ghostRespawn("pink_ghost_p", pinkGhostPos);
        ghostRespawn("blue_ghost_p", blueGhostPos);
        ghostRespawn("orange_ghost_p", orangeGhostPos);
    }
}