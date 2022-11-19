using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket4 : MonoBehaviour
{
    public GameObject enemy;
    public float speed;
    public float rocketStrength;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 moveDirection = transform.forward;
        if (enemy != null)
        {
            moveDirection = (enemy.transform.position - transform.position).normalized * speed;
            transform.LookAt(enemy.transform);
        }
        transform.position += moveDirection * Time.deltaTime;
        
        if (Vector3.Distance(player.transform.position, transform.position) > 15) Destroy(gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enemy == null) return;
        if (collision.gameObject.CompareTag(enemy.tag))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = -collision.contacts[0].normal;
            rb.AddForce(away * rocketStrength, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }
}
