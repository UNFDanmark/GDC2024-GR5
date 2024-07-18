using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    float timer = 5f;
    float x;
    float z;
    private bool startTimer;
    public GameObject victoryScreen;

    public CharacterController controller;
    

    public float speed = 12f;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public float jump = 5f;
    public float superJump = 10f;
    private bool isMoving;
    
    

    private float bonusJump;
    public float jumpPickup;
    private float maxJumpAmount;
    private float jumpAmount = 1;
    public bool dynamite;
    public float lightfallsound = -5f;
    public float fallsound = -15f;
    public float fallingsound = -5f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public AudioController audioController;

    public AudioSource music;
    public AudioClip mainTrack;
    public AudioClip megaSuperHemmeligtTrack;
    public AudioClip secondaryTrack;
	

    public bool secondaryIsPlaying;
    
    void Start()
    {
        music.clip = mainTrack;
        music.Play();
    }

    void Update()
    {

       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
	

	if (startTimer == true)
	{
		quitTimer();
	}	

	        
        
        if (!isGrounded && velocity.y < fallingsound)
        {
            audioController.playAudio(9);
        }
        
        if (isGrounded && velocity.y < lightfallsound && velocity.y > fallsound)
        {
            audioController.playAudio(3);
            
        }
        if (isGrounded && velocity.y < fallsound)
        {
            audioController.playAudio(1);
            
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            maxJumpAmount = jumpAmount + jumpPickup;
            audioController.stopAudio(9);
        }
        
        


        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            maxJumpAmount -= 1;

            audioController.playAudio(0);
            


        }

        if (isGrounded == false && Input.GetButtonDown("Jump") && jumpPickup > 0 && maxJumpAmount > 0)
        {
            velocity.y = Mathf.Sqrt(superJump * -2f * gravity);
            maxJumpAmount -= 1;

            audioController.playAudio(0);
            
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (Time.deltaTime * speed));

        velocity.y += gravity * Time.deltaTime;
 
        controller.Move(velocity * Time.deltaTime);
       

        if (Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.W))
        {
            music.clip = megaSuperHemmeligtTrack;
            music.Play();
        }
        else if (jumpPickup == 1f && music.clip != megaSuperHemmeligtTrack && music.clip != secondaryTrack)
        {
            music.clip = secondaryTrack;
            music.Play();
        }
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("FinalLevel");
        }
        
        if (z != 0 || x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving == false )
        {
            audioController.stopAudio(6);
            audioController.stopAudio(7);
        }
        
    }
    private void quitTimer()
    {
	timer -= Time.deltaTime;
        if (timer <= 0)
        {
	    Debug.Log("done");
            Application.Quit();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("WoodFloor") && isGrounded && isMoving) //&& (no other of the same sound is playing
        {
            
            audioController.playAudio(6);
            
        }
        if (hit.gameObject.CompareTag("StoneFloor") && isGrounded && isMoving) //&& (no other of the same sound is playing
        {
            
            audioController.playAudio(7);
            
        }
        if (hit.gameObject.CompareTag("End")) 
        {
            victoryScreen.SetActive(true);
            audioController.playAudio(8);
            transform.position = new Vector3(1f, 17.1f, 5f);
	    startTimer = true;
            
		
            
        }
    }
        
}   

    