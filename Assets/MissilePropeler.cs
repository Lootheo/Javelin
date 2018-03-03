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
	
	public Rigidbody rb;
	public Transform propeler;

	public MissileTargetDetection missileTargetDetection;

	
	// Use this for initialization
	void Awake () {
		missileTargetDetection = GetComponent<MissileTargetDetection>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ApplyThrustForce();
        Vector3 targetDir = missileTargetDetection.missileTarget.position - transform.position;
        float step = steeringSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
	}

	void ApplyThrustForce(){
		if(thrusterOn)
			rb.AddForceAtPosition(transform.forward * thrust,propeler.position);
	}



}
