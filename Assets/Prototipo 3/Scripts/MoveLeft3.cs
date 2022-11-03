using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft3 : MonoBehaviour
{
    private float speed = 20;
    private PlayerController3 playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }
        if (transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
