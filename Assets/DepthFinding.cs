using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFinding : MonoBehaviour {

	NodeManager nodeManager;
	Node[,,] nodes;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		nodeManager = FindObjectOfType<NodeManager>();
		nodes = nodeManager.CreateNodes();
		StartCoroutine(FindPath());
	}

	IEnumerator FindPath(){
		yield return new WaitForSeconds(0.3f);
		List<Node> openList = new List<Node>();
		List<Node> closedList = new List<Node>();
		Transform target = nodeManager.target;
		Node currentNode = nodeManager.GetStartingNode(nodes);
		openList.Add(currentNode);
		int counter = 0;
		while(!currentNode.hasTarget && counter <50){
		yield return new WaitForSeconds(0.3f);
			counter++;
			Vector3 nodePosition = nodeManager.GetNodePosition(nodes,currentNode);
			List<Node> adjacentNodes = nodeManager.GetAdjacentNodes(nodes, (int)nodePosition.x,(int)nodePosition.y,(int)nodePosition.z);
			foreach(Node node in adjacentNodes){
				if(!openList.Contains(node) && !closedList.Contains(node)){
					openList.Add(node);
					nodeManager.PaintNode(node,1);
				}
			}
			closedList.Add(currentNode);
			openList.Remove(currentNode);
     		openList.Sort(delegate(Node a, Node b)
				{return Vector3.Distance(target.transform.position,a.transform.position)
				.CompareTo(
					Vector3.Distance(target.transform.position,b.transform.position) );
				});
			currentNode = openList[0];
		}
		Debug.Log("Finished");
	}
}
