using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodableRock : MonoBehaviour
{
    public Transform other;
    public GameObject explosionEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //check distance to player from each dynamite
            float dist = (other.transform.position - transform.position).sqrMagnitude;
            
            
            
            //place dynamite on the nearest location
            gameObject.SetActive(false);
            
            Instantiate(explosionEffect, transform.position, transform.rotation);
            
            
            
        }
        //change player bool for placement of dynamite to true 
        
        
        
    }
     
}
