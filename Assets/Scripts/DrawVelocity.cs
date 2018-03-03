using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawVelocity : MonoBehaviour {
	Rigidbody rb;
	LineRenderer lineRenderer;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer.SetPosition(1,transform.InverseTransformDirection(rb.velocity).normalized*10);
	}
}
