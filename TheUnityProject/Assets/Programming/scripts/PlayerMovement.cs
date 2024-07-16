using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    float x;
    float z;
    
    public GameObject gameOverScreen;
        
    public CharacterController controller;

    public float speed = 12f;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public float jump = 5f;
    public float superJump = 10f;
    
    private float bonusJump;
    public float jumpPickup;
    private float maxJumpAmount;
    private float jumpAmount = 1;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public AudioController audioController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        

    }


    // Update is called once per frame
    void Update()
    {
        
        
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            maxJumpAmount = jumpAmount + jumpPickup;
            audioController.playAudio(1);
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
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //sprint


        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Character using Controller");
        }
        /*      LAV DETTE OM TIL ET PICKUP SYSTEM AF EN ANDEN ONCE PER USE POWER
        if (Input.GetKeyDown(KeyCode.X) && "pickup" == true)
        {
            velocity.y = Mathf.Sqrt("pickupPower" * -2f * gravity);
            "pickup" -= 1f;
        }
        */
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))//ændrer dette her string til en hvilken som helst fjende eller farlig ting ved dets tag navn.
        {  
            gameOverScreen.SetActive(true);
        }
    }
    
    
    
    
}
