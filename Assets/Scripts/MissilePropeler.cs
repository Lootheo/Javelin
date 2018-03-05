using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePropeler : MonoBehaviour {
	[Header("Thruster")]
	public bool thrusterOn;
	[Range(0,100)]
	public float thrust;

	[Range(0,20)]
	public float steeringSpeed;

	[Range(0,40)]
	public float upwardsSpeed;
	
	public Rigidbody rb;
	public Transform propeler;

	public bool flyingUpwards,seeking;

	public MissileTargetDetection missileTargetDetection;

	
	// Use this for initialization
	void Awake () {
		missileTargetDetection = GetComponent<MissileTargetDetection>();
		StartCoroutine(IgniteMissile());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ApplyThrustForce();
		if(flyingUpwards){
			Vector3 rotateAmount = Vector3.Cross(Vector3.up,transform.forward);
			rb.angularVelocity = -rotateAmount*steeringSpeed;
		}else if(seeking){
        	Vector3 targetDir = missileTargetDetection.missileTarget.position - rb.position;
		 	Vector3 rotateAmount = Vector3.Cross(targetDir.normalized,transform.forward);
		 	rb.angularVelocity = -rotateAmount*steeringSpeed*10;
		 }
	}

	void ApplyThrustForce(){
		if(flyingUpwards)
			rb.AddForceAtPosition(transform.forward * upwardsSpeed,propeler.position);
		else if(thrusterOn)
			rb.velocity= transform.forward*thrust;//(transform.forward * thrust,propeler.position);
	}

	IEnumerator IgniteMissile(){
		yield return new WaitForSeconds(0.5f);
		thrusterOn = true;
		flyingUpwards=true;
		propeler.Find("WhiteSmoke").gameObject.SetActive(true);
		StartCoroutine(SeekTarget());
	}

	IEnumerator SeekTarget(){
		yield return new WaitForSeconds(5.0f);
		flyingUpwards = false;
		seeking = true;
		thrusterOn = false;
		yield return new WaitForSeconds(0.5f);
		thrusterOn = true;
	}
}
