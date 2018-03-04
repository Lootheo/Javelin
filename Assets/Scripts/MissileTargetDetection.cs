using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTargetDetection : MonoBehaviour {

	public Transform missileTarget;
	
	public Vector3 distance = Vector3.zero;
	public void Awake()
	{
		missileTarget = GameObject.FindGameObjectWithTag("Target").transform;
	}
	public  void Update()
	{
		distance = (transform.position-missileTarget.transform.position);
	}
}
