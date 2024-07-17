using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{

	[SerializeField] private GameObject timer;
	[SerializeField] private TimeKeep timererer;
	[SerializeField] private float timerer;
	public GameObject chronos;
	Text timerText;

	string strText;
    // Start is called before the first frame update
    void Start()
    {
     timerText = gameObject.GetComponent<Text>();
     //timererer = timer.GetComponent<timer>().timerer;
     timererer = chronos.GetComponent<TimeKeep>();
     
    }

    // Update is called once per frame 
    void LateUpdate()
    {
	    
	    timerer = timererer.timer;
	strText = (timerer/60).ToString("#.0");
	timerText.text = "it took you " + strText + " minutes to reach the surface";
    }

}
