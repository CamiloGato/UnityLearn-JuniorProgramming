using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float speed = 5;
    [SerializeField] private float leftBound = -10;
    [SerializeField] private float rightBound = 10;
    [SerializeField] private int life = 3;
    private float horizontalInput;
    private float verticalInput;

    public static int score;
    private int currentLife;

    private void Start()
    {
        currentLife = life;
    }

    void Update()
    {
        // Movimiento con bordes
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * (Time.deltaTime * speed));
        
        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentLife--;
            Destroy(other.gameObject);
            Debug.Log("Vidas: " + currentLife);
            if ( currentLife < 1)
            {
                currentLife = life;
                score = 0;
                Debug.Log("GAME OVER");
            }
        }
    }
    
}
