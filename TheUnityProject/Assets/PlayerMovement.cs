using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float x;
    float z;
    
    public GameObject gameOverScreen;
        
    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f;
    public float jump = 5f;

    private bool bonusJump;
    private float jumpPickup;
    
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    private Vector3 velocity;

    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }


    // Update is called once per frame
    void Update()
    {

        if (jumpPickup > 1f)
        {
            bonusJump = true;
        }
        else
        {
            bonusJump = false;
        }
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }
    
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(Time.deltaTime * move * speed);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Sprint


        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Character using Controller");
        }

        if (Input.GetKeyDown(KeyCode.X) && bonusJump = true)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))//ændrer dette her string til en hvilken som helst fjende eller farlig ting ved dets tag navn.
        {  
            gameOverScreen.SetActive(true);
        }
    }
    
    
    
    
}
