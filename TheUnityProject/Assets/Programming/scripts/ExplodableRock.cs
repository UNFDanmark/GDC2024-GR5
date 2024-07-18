using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExplodableRock : MonoBehaviour
{
    float timer = 3f;
    public Transform other;
    public GameObject explosionEffect;
    private bool clickedDynamite;
    
    
    [SerializeField] private GameObject placeholder1;
    [SerializeField] private GameObject placeholder2;
    [SerializeField] private GameObject placeholder3;
    [SerializeField] private GameObject placeholder4;
    [SerializeField] private GameObject Hint1;
    [SerializeField] private GameObject Hint2;
    [SerializeField] private GameObject Hint3;
    [SerializeField] private GameObject Hint4;
    
    
    
    
    
    private GameObject curPlaceholder;
    private float minDistance;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject player;
    
    public AudioController audioController;
    
    private PlayerMovement playerMovement;
    private bool dynamite;

    public Animator animator;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        audioController = GameObject.Find("JohnnyBgoode").GetComponent<AudioController>();
    }

    
    void Update()
    {
        dynamite = playerMovement.dynamite;
        
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
            audioController.playAudio(4);
            
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(parent);
            
        }
    }

   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && dynamite)
        {
            float dist1 = (other.transform.position - placeholder1.transform.position).sqrMagnitude;
            float dist2 = (other.transform.position - placeholder2.transform.position).sqrMagnitude;
            float dist3 = (other.transform.position - placeholder3.transform.position).sqrMagnitude;
            float dist4 = (other.transform.position - placeholder4.transform.position).sqrMagnitude;

            float[] distances = {dist1, dist2, dist3, dist4};
            minDistance = distances.Min();
            if (dist1 == minDistance)
            {
                Hint1.SetActive(true);
            }
            else
            {
                Hint1.SetActive(false);
            }
            if (dist2 == minDistance)
            {
                Hint2.SetActive(true);
            }
            else
            {
                Hint2.SetActive(false);
            }
            if (dist3 == minDistance)
            {
                Hint3.SetActive(true);
            }
            else
            {
                Hint3.SetActive(false);
            }
            if (dist4 == minDistance)
            {
                Hint4.SetActive(true);
            }
            else
            {
                Hint4.SetActive(false);
            }
            
                
                
            if (dist1 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder1.SetActive(true);
                audioController.playAudio(5);
                clickedDynamite = true;
                Destroy(Hint1);
                animator.SetTrigger("PowerupsogDynamit");
            }
            else if (dist2 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder2.SetActive(true);
                audioController.playAudio(5);
                clickedDynamite = true;
                Destroy(Hint2);
                animator.SetTrigger("PowerupsogDynamit");
            }
            else if (dist3 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder3.SetActive(true);
                audioController.playAudio(5);
                clickedDynamite = true;
                Destroy(Hint3);
                animator.SetTrigger("PowerupsogDynamit");
            }
            else if (dist4 == minDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(1)))
            {
                placeholder4.SetActive(true);
                audioController.playAudio(5);
                clickedDynamite = true;
                Destroy(Hint4);
                animator.SetTrigger("PowerupsogDynamit");
            }

        }
        
    }
     
}
