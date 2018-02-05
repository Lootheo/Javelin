using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLookAt : MonoBehaviour {
	public GameObject target;

	public float thrust;
	public float missileTorque;
	Rigidbody rb;
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		transform.LookAt(target.transform);
		rb.AddForce(transform.forward * thrust);
	}
}
