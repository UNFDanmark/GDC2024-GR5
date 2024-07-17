using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
	[SerializeField] public float timerer;
	Text timerText;
    // Start is called before the first frame update
    void Start()
    {
     timerText = gameObject.GetComponent<text>();   
    }

    // Update is called once per frame
    void Update()
    {
        timerer += Time.deltaTime;
	timerText = "you took" + timerer + " seconds to climb";
    }
}
