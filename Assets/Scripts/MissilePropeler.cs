using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePropeler : MonoBehaviour {
	[Header("Thruster")]
	public bool thrusterOn;
	[Range(0,12)]
	public float thrust;

	[Range(0,20)]
	public float steeringSpeed;

	[Range(0,40)]
	public float upwardsSpeed;
	
	public Rigidbody rb;
	public Transform propeler;

	public bool flyingUpwards;

	public MissileTargetDetection missileTargetDetection;

	
	// Use this for initialization
	void Awake () {
		missileTargetDetection = GetComponent<MissileTargetDetection>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ApplyThrustForce();
        Vector3 targetDir = missileTargetDetection.missileTarget.position - rb.position;
		if(flyingUpwards){
			Vector3 rotateAmount = Vector3.Cross(Vector3.up,transform.forward);
			rb.angularVelocity = -rotateAmount*steeringSpeed;
		}
	}

	void ApplyThrustForce(){
		if(flyingUpwards)
			rb.AddForceAtPosition(transform.forward * upwardsSpeed,propeler.position);
		if(thrusterOn)
			rb.AddForceAtPosition(transform.forward * thrust,propeler.position);
	}



}
