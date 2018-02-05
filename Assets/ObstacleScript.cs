using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObstacleScript : MonoBehaviour {

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.name == "Missile"){
		Debug.Log("Obstacle Reached, Restarting Scene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
