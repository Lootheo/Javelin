using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
	public bool traversable = true;
	public bool hasTarget = false;
	public bool startingPoint = false;



	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		if(other.gameObject.tag == "Obstacle"){
			traversable = false;
		}else if(other.gameObject.tag == "Target"){
			hasTarget = true;
		}else if(other.gameObject.name == "Missile"){
			startingPoint = true;
		}
	}
}
