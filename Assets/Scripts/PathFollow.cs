using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour {
	//Manage follow path of an object depending on the type of path provided
	bool pathStarted = false;

	List<Node> pathToFollow;
	Node nextNode;

	float speed=10;
	

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(pathStarted){
			MoveToNode(nextNode);
		}
	}

	//Get a list of nodes, puts the object on the first node and starts the path movement
	public void StartPath(List<Node> _pathToFollow){
		pathToFollow = _pathToFollow;
		transform.position = pathToFollow[0].transform.position;
		nextNode = pathToFollow[1];
		pathStarted = true;
	}

	//Moves to the next node, if the distance to the node is too low, the node to follow will be the next node of the list
	void MoveToNode(Node node){
		transform.LookAt(nextNode.transform.position);


	}
}
