using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{

	[SerializeField] public float timerer;
	[SerializeField] private int remainer;
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
	
	strText = (timerer/60).ToString("#.0");
	timerText.text = "it took you " + strText + "seconds to reach the surface";
    }

}
