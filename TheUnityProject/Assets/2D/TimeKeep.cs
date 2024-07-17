using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeep : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer += Time.deltaTime;
    }
}
