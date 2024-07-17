using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
	[SerializeField] GameObject cam;
	
    void Start()
    {
	    if (cam == null) 
        Debug.LogError("camera not set for startScreen. add this through the inspector");
	    cam.transform.GetComponent<Mouselooking>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.W)||Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1))
        {
	        cam.transform.GetComponent<Mouselooking>().enabled = true;
			Destroy(gameObject);
		}
    }
}
