using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    int speed = 5;
    public Rigidbody rb;

    private Transform transform;

    private float yrotation;
    private float zrotation;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();

    }

    
    void Update()
    {
        PlayerMovement();
    }

    

    private void PlayerMovement()
    {
        zrotation = transform.rotation.z;
        yrotation = transform.rotation.y;
        Vector3 movement = rb.velocity;
        movement.x = Input.GetAxisRaw("Horizontal") * speed * yrotation;
        movement.z = Input.GetAxisRaw("Vertical") * speed * zrotation;
        rb.velocity = movement;
        
    }


}
