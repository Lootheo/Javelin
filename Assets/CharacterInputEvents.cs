using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputEvents : MonoBehaviour {


	public JavelinAnimator javelinAnimator;

	public Camera mainCamera, aimCamera, uiCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
