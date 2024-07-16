using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExplodableRock : MonoBehaviour
{
    float timer = 3f;
    public Transform other;
    //public GameObject explosionEffect;
    //public GameObject DynamiteLit;
    private bool clickedDynamite;
    
    
    [SerializeField] private GameObject placeholder1;
    [SerializeField] private GameObject placeholder2;
    [SerializeField] private GameObject placeholder3;
    [SerializeField] private GameObject placeholder4;
    private GameObject curPlaceholder;
    private float minDistance;
    [SerializeField] private GameObject parent;

    //public AudioSource fuse;
    //public AudioSource explosionSound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clickedDynamite)
        {
            
            explosionTimer();
            
        }
    }
    void explosionTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Instantiate(explosionEffect, transform.position, transform.rotation);
            //Destroy(explosionEffect);
            Destroy((parent), 0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //check distance to player from each dynamite
            float dist1 = (other.transform.position - placeholder1.transform.position).sqrMagnitude;
            float dist2 = (other.transform.position - placeholder2.transform.position).sqrMagnitude;
            float dist3 = (other.transform.position - placeholder3.transform.position).sqrMagnitude;
            float dist4 = (other.transform.position - placeholder4.transform.position).sqrMagnitude;

            float[] distances = {dist1, dist2, dist3, dist4};
            minDistance = distances.Min();
            
            if (dist1 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder1.SetActive(true);
                //Instantiate(DynamiteLit, transform.position, transform.rotation);
                clickedDynamite = true;
            }
            else if (dist2 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder2.SetActive(true);
                //Instantiate(DynamiteLit, transform.position, transform.rotation);
                clickedDynamite = true;
            }
            else if (dist3 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder3.SetActive(true);
                //Instantiate(DynamiteLit, transform.position, transform.rotation);
                clickedDynamite = true;
            }
            else if (dist4 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder4.SetActive(true);
                //Instantiate(DynamiteLit, transform.position, transform.rotation);
                clickedDynamite = true;
            }
           
            
            

        }
        
        
        
    }

    
     
}
