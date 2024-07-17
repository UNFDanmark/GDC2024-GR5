using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmLerp : MonoBehaviour
{
	/*
    [SerializeField] private Transform arm;
	[SerializeField] private Transform cam;
	

	[SerializeField] Quaternion lastRot;
	[SerializeField] Quaternion curRot;

    [SerializeField] private Vector3 distToTarget = new Vector3(0.5943477f, -0.7366863f, 1.614395f);
	[SerializeField] Vector3 axis;
	[SerializeField] Vector3 angularVelocity;

    [SerializeField] private float distDampener = 1f;

    [SerializeField] private float rotDampener = 1f;

	[SerializeField] float angle;

    // Start is called before the first frame update
    void Start()
    {
        lastRot = arm.transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
	    /*
	
        Quaternion curRot = transform.rotation;


	Quaternion deltaRot = curRot * Quaternion.inverse(lastRot); //Quaternion.inverse does not exist
	deltaRot.ToAngleAxis(out angle, out axis); 

	if(angle > 180f){
	angle -= 180;
	}
	angularVelocity = Vector3.Lerp(axis * angle * Mathf.Deg2Rad / Time.deltaTime);

	angularVelocity = Vector3.Lerp(angularVelocity,Vector3.zero, rotDampener*Time.deltaTime);

	transform.rotation *= Quaternion.Euler(angularVelocity * Time.deltaTime);

	lastRot = curRot;
	*/
    }
/*
	void FromCamPOV{
	Vector3 toPos = arm.position + (arm.rotation * distToTarget);
        Vector3 curPos = Vector3.Lerp(this.transform.position, toPos, distDampener * Time.deltaTime);
        this.transform.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(arm.position - this.transform.position, arm.up);
        Quaternion curRot = Quaternion.Slerp(this.transform.rotation, toRot, rotDampener * Time.deltaTime);
        this.transform.rotation = curRot;
	}
*/
}

