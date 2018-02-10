using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    //Manage follow path of an object depending on the type of path provided
    bool pathStarted = false;

    List<Node> pathToFollow;
    Node nextNode;

    float speed = 20;


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (pathStarted)
        {
            MoveToNode(nextNode);
        }
    }

    //Get a list of nodes, puts the object on the first node and starts the path movement
    public void StartPath(List<Node> _pathToFollow)
    {
        pathToFollow = _pathToFollow;
        Debug.Log(pathToFollow.Count);
        Debug.Log(pathToFollow[0].gameObject.name);
        transform.position = pathToFollow[0].transform.position;

        nextNode = pathToFollow[1];
        pathStarted = true;
    }

    //Moves to the next node, if the distance to the node is too low, the node to follow will be the next node of the list
    void MoveToNode(Node node)
    {
        transform.LookAt(nextNode.transform.position);
        if (Vector3.Distance(transform.position, node.transform.position) > 1.0f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, node.transform.position, step);
        }else{
			nextNode = GetNextNode(node);
		}
    }

    private Node GetNextNode(Node node)
    {
		for(int i =0;i<(pathToFollow.Count-1);i++){
			if(node == pathToFollow[i]){
				return pathToFollow[i+1];
			}
		}
		return null;
    }
}
