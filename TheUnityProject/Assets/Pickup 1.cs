using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup1 : MonoBehaviour
{
    private Transform transform;

    [SerializeField] private float rotationSpeed = 200;
    
    public GameObject pickupEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
     void Update()
    {
        
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f); 
        
        
        

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Pickup(other);
            
            Destroy(gameObject);
        }

        void Pickup(Collider player)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation); //add nogle effekter i inspektoren

            PlayerMovement pickup = player.GetComponent<PlayerMovement>();
            pickup.jumpPickup += 1f;


            // giv "PlayerMovement" +1 bonusJump


        }
    }
    
}
