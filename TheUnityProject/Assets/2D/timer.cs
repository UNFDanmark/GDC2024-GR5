using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
	
	[SerializeField] public float timerer;
	Text timerText;
	string strText;
    // Start is called before the first frame update
    void Start()
    {
     timerText = gameObject.GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        timerer += Time.deltaTime;
	strText = timerer.ToString("#.0");
	timerText.text = strText;
    }
    

    }
