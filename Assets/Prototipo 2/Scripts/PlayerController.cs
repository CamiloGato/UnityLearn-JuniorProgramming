using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float speed = 5;
    [SerializeField] private float leftBound = -10;
    [SerializeField] private float rightBound = 10;
    private float horizontalInput;

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
        transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));
        
        // Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(foodPrefab, transform.position, foodPrefab.transform.rotation);
        }
    }
}
