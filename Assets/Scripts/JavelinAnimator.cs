using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JavelinAnimator : MonoBehaviour {
	Vector3 originalPosition, originalRotation;
	public Transform targetAimPosition;

	public bool aiming;
	bool doingAiming;
	bool resetting = false;
	public bool finishedAiming = false;

	Tweener aim1, aim2;

	// Use this for initialization
	void Start () {
		originalRotation = transform.localRotation.eulerAngles;
		originalPosition = transform.localPosition;
	}
	void Aim(){
		if(!doingAiming){
			doingAiming = true;
			resetting = false;
			// Regular TO tween
			aim1 = transform.DOLocalMove(targetAimPosition.localPosition, 0.4f).SetId("Aim1");
			aim2 = transform.DOLocalRotate(targetAimPosition.localRotation.eulerAngles,0.4f).OnComplete(()=>finishedAiming=true).SetId("Aim2");
		}
	}

	void Reset(){
		if(!resetting){
			resetting = true;
			finishedAiming = false;
			doingAiming =false;
			// Regular TO tween
			transform.DOLocalMove(originalPosition, 1);
			transform.DOLocalRotate(originalRotation,1);
		}
	}
	// Update is called once per frame
	void Update () {
		if(aiming){
			Aim();
		}else{
			Reset();
		}
	}
}
