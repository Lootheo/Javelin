using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomMovement : MonoBehaviour {


	[Range(0,10)]
	public float waitTime;
	[Range(0,100)]
	public float speed;

	Vector3 normalizedDirection;
	// Use this for initialization
	void Start () {
		normalizedDirection = Random.insideUnitSphere;
		StartCoroutine(SetDirection());
	}
	IEnumerator SetDirection(){
		while(true){
		normalizedDirection = Random.insideUnitSphere;
		yield return new WaitForSeconds(waitTime);
		}
	}
	// Update is called once per frame
	void Update () {
		transform.position += normalizedDirection*speed*Time.deltaTime;
	}
}
