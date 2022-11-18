using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    public bool gameOver;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private int jumpAmount;
    private SpawnManager3 spawnManagerScript;
    private float speed;
    private bool stop;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager3>();
        Physics.gravity *= gravityModifier;
        speed = spawnManagerScript.speed;
        StartCoroutine(Intro());
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpAmount < 2)
        {
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            jumpAmount++;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            spawnManagerScript.ChangeSpeed(speed*2);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            spawnManagerScript.ChangeSpeed(speed);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpAmount = 0;
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    IEnumerator Intro()
    {
        gameOver = true;
        yield return new WaitUntil(() =>
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * speed/2));
            return transform.position.x > 3;
        });
        gameOver = false;
    }
}
