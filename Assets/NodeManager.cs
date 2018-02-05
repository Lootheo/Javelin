using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {

	public GameObject nodeGO;
	

	public int gridWidth,gridHeight,gridDepth;
	public float spacingX, spacingY, spacingZ;
	Node [,,] nodes;
	public Material pathMaterial, emptyMaterial, traversedMaterial, obstacleMaterial;
	public Transform target;


	// Use this for initialization
	void Awake () {
		CreateNodes();
		StartCoroutine(DepthFinding(gridWidth/2,gridHeight/2,gridDepth/2));
	}
	
	IEnumerator DepthFinding(int x, int y, int z){
		List<Node> openList = new List<Node>();
		List<Node> closedList = new List<Node>();
		Node currentNode = nodes[x,y,z];
		openList.Add(currentNode);
		int counter = 0;
		while(!currentNode.hasTarget && counter <50){
			Debug.Log(counter);
			counter++;
			Vector3 nodePosition = GetNodePosition(currentNode);
			List<Node> adjacentNodes = GetAdjacentNodes((int)nodePosition.x,(int)nodePosition.y,(int)nodePosition.z);
			foreach(Node node in adjacentNodes){
				if(!openList.Contains(node) && !closedList.Contains(node)){
					openList.Add(node);
					PaintNode(node,1);
				}
			}
			PaintNode(currentNode,0);
			closedList.Add(currentNode);
			openList.Remove(currentNode);
			yield return new WaitForSeconds(0.5f);
     		openList.Sort(delegate(Node a, Node b)
				{return Vector3.Distance(target.transform.position,a.transform.position)
				.CompareTo(
					Vector3.Distance(target.transform.position,b.transform.position) );
				});
			currentNode = openList[0];
		}
		Debug.Log("Finished");
	}

	void CreateNodes(){
		nodes = new Node[gridWidth,gridHeight,gridDepth];
		for(int i = 0;i<gridWidth;i++){
			for(int j=0;j<gridHeight;j++){
				for(int k = 0;k<gridDepth;k++){
					Vector3 nodePosition = new Vector3(transform.position.x+spacingX*(i-(gridWidth/2)), transform.position.y+spacingY*(j-(gridHeight/2)), transform.position.z+spacingZ*(k-(gridDepth/2)));
					GameObject node = Instantiate(nodeGO, nodePosition,Quaternion.identity);
					nodes[i,j,k] = node.GetComponent<Node>();
				}
			}
		}
	}
	List<Node> GetAdjacentNodes(int x, int y, int z){
		List<Node> adjacentNodes = new List<Node>();
		for(int i = -1;i<=1;i++){
			for(int j = -1;j<=1;j++){
				for(int k = -1;k<=1;k++){
					if(IsNodeAvailable(x+i,y+j,z+k)){
						adjacentNodes.Add(nodes[x+i,y+j,z+k]);
					}
				}
			}
		}
		return adjacentNodes;
	}

	Vector3 GetNodePosition(Node node){
		for(int i = 0;i<gridWidth;i++){
			for(int j=0;j<gridHeight;j++){
				for(int k = 0;k<gridDepth;k++){
					if (node == nodes[i,j,k]){
						return new Vector3(i,j,k);
					}
				}
			}
		}
		Debug.LogError("Node not found in matrix");
		return new Vector3();
	}

	bool IsNodeAvailable(int x, int y, int z){
		if(x<gridWidth && y<gridHeight && z<gridDepth && x>=0 && y>=0 && z>=0 && nodes[x,y,z].traversable){
			return true;
		}
		else{
			return false;
		}
	}
	void PaintNode(int x, int y, int z){
		nodes[x,y,z].GetComponent<MeshRenderer>().material = traversedMaterial;
	}
	void PaintNode(Node node, int materialType=0){
		node.GetComponent<MeshRenderer>().enabled = true;
		if(materialType == 0)
			node.GetComponent<MeshRenderer>().material = emptyMaterial;
		else
			node.GetComponent<MeshRenderer>().material = traversedMaterial;
	}
}
