using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmLerp : MonoBehaviour
{
    [SerializeField] private Transform arm;

    [SerializeField] private Vector3 distToTarget = new Vector3(0.5943477f, -0.7366863f, 1.614395f);

    [SerializeField] private float distDampener = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 toPos = arm.position + (arm.rotation * distToTarget);
        Vector3 curPos = Vector3.Lerp(this.transform.position, toPos, distDampener * Time.deltaTime);
        this.transform.position = curPos;


    }
}

