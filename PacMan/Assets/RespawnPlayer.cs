using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }
}
