using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputEvents : MonoBehaviour {


	public JavelinAnimator javelinAnimator;
	[Header("Cameras")]
	public Camera mainCamera;
	public Camera aimCamera, uiCamera;

	[Header("Firing")]
	public GameObject missile;
	public Transform shootPoint;

	[Range(0,10000)]
	public float missileLaunchForce;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){

			GameObject rocket= Instantiate(missile, shootPoint.position,shootPoint.rotation);
			rocket.GetComponent<Rigidbody>().AddForce(transform.forward*missileLaunchForce);
		}
		if(Input.GetMouseButton(1)){
			javelinAnimator.aiming = true;
		}else{
			javelinAnimator.aiming = false;
		}
		if(javelinAnimator.finishedAiming){
			EnableAimCamera(true);
		}else{
			EnableAimCamera(false);
		}
	}

	void EnableAimCamera(bool flag){
		aimCamera.enabled = flag;
		uiCamera.enabled =flag;
		mainCamera.enabled = !flag;
	}
}
