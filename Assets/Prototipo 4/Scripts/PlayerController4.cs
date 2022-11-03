using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    public float speed;
    public GameObject powerupIndicator;
    
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerup;
    
    
    private void Start()
    { 
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * (speed * fowardInput));
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") || !hasPowerup) return;
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
        enemyRigidbody.AddForce(awayFromPlayer * 50, ForceMode.Impulse);
        // Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Powerup")) return;
        hasPowerup = true;
        powerupIndicator.gameObject.SetActive(true);
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownRoutine());
    }
    
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
