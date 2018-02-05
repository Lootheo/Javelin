using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFinding : MonoBehaviour {

	// IEnumerator FindPath(int x, int y, int z){
	// 	List<Node> openList = new List<Node>();
	// 	List<Node> closedList = new List<Node>();
	// 	Node currentNode = nodes[x,y,z];
	// 	openList.Add(currentNode);
	// 	int counter = 0;
	// 	while(!currentNode.hasTarget && counter <50){
	// 		Debug.Log(counter);
	// 		counter++;
	// 		Vector3 nodePosition = GetNodePosition(currentNode);
	// 		List<Node> adjacentNodes = GetAdjacentNodes((int)nodePosition.x,(int)nodePosition.y,(int)nodePosition.z);
	// 		foreach(Node node in adjacentNodes){
	// 			if(!openList.Contains(node) && !closedList.Contains(node)){
	// 				openList.Add(node);
	// 				PaintNode(node,1);
	// 			}
	// 		}
	// 		PaintNode(currentNode,0);
	// 		closedList.Add(currentNode);
	// 		openList.Remove(currentNode);
	// 		yield return new WaitForSeconds(0.5f);
    //  		openList.Sort(delegate(Node a, Node b)
	// 			{return Vector3.Distance(target.transform.position,a.transform.position)
	// 			.CompareTo(
	// 				Vector3.Distance(target.transform.position,b.transform.position) );
	// 			});
	// 		currentNode = openList[0];
	// 	}
	// }	
}
