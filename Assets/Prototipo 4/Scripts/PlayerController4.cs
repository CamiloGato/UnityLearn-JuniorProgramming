using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    public float speed;
    public GameObject powerupIndicator;
    public GameObject rocket;
    
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerup;
    private int powerUpId;
    
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

        if (Input.GetKeyDown(KeyCode.Space) && hasPowerup)
        {
            GameObject[] enemies;
            switch (powerUpId)
            {
                case 2:
                    enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        Vector3 direction = enemy.transform.position - transform.position;
                        var rock = Instantiate(rocket, transform.position, Quaternion.Euler(direction));
                        rock.GetComponent<Rocket4>().enemy = enemy;
                    }
                    break;
                case 3:
                    enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    var gameObjects = enemies.Where( enemy => Vector3.Distance(
                        enemy.transform.position, 
                        gameObject.transform.position) < 10 ).ToArray();
                    StartCoroutine(SmashAttack(gameObjects));
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * 50, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            var powerup = other.GetComponent<PowerUp4>();
            powerUpId = powerup.id;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpId = 0;
        powerupIndicator.gameObject.SetActive(false);
    }

    IEnumerator SmashAttack(GameObject[] enemies)
    {
        playerRb.velocity = Vector3.zero;
        playerRb.AddForce(Vector3.up * 100, ForceMode.Impulse);
        yield return new WaitForSeconds(0.3f);
        playerRb.AddForce(Vector3.down * 200, ForceMode.Impulse);
        foreach (GameObject enemy in enemies)
        {
            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (enemy.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * 50, ForceMode.Impulse);
        }
    }
    
}
