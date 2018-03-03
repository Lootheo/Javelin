using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RocketInfoUI : MonoBehaviour {

	public Text speedText;

	MissilePropeler missilePropeler;
	// Use this for initialization
	void Awake()
	{
		missilePropeler = FindObjectOfType<MissilePropeler>();
	} 
	void FixedUpdate()
	{
		if(missilePropeler !=null){
		speedText.text = "Rocket Speed: " + missilePropeler.rb.velocity.ToString();}
	}

}
