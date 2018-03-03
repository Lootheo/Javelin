using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetExplode : MonoBehaviour {

	public GameObject explosionParticle;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerStay(Collider other)
	{
		Instantiate(explosionParticle,transform.position,Quaternion.identity);
		Destroy(other.gameObject);
		Destroy(this.gameObject);
		
	}
}
