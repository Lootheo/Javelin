using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.name == "Missile"){
		Destroy(hit.gameObject);
		transform.Find("T95-1").gameObject.SetActive(false);
		transform.GetChild(0).gameObject.SetActive(true);
		}
	}
}
