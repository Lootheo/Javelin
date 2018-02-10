using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {

	public GameObject nodeGO;
	

	public int gridWidth,gridHeight,gridDepth;
	public float spacingX, spacingY, spacingZ;
	public Material []nodeMaterials;
	public Transform target;



	public Node[,,] CreateNodes(){
		Node[,,] nodes = new Node[gridWidth,gridHeight,gridDepth];
		for(int i = 0;i<gridWidth;i++){
			for(int j=0;j<gridHeight;j++){
				for(int k = 0;k<gridDepth;k++){
					Vector3 nodePosition = new Vector3(transform.position.x+spacingX*(i-(gridWidth/2)), transform.position.y+spacingY*(j-(gridHeight/2)), transform.position.z+spacingZ*(k-(gridDepth/2)));
					GameObject node = Instantiate(nodeGO, nodePosition,Quaternion.identity);
					nodes[i,j,k] = node.GetComponent<Node>();
				}
			}
		}
		return nodes;
	}
	public List<Node> GetAdjacentNodes(Node[,,] nodes, int x, int y, int z){
		List<Node> adjacentNodes = new List<Node>();
		for(int i = -1;i<=1;i++){
			for(int j = -1;j<=1;j++){
				for(int k = -1;k<=1;k++){
					if(IsNodeAvailable(nodes,x+i,y+j,z+k)){
						adjacentNodes.Add(nodes[x+i,y+j,z+k]);
					}
				}
			}
		}
		return adjacentNodes;
	}

	public Vector3 GetNodePosition(Node[,,] nodes, Node node){
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

	public Node GetStartingNode(Node[,,]nodes){
		for(int i = 0;i<gridWidth;i++){
			for(int j=0;j<gridHeight;j++){
				for(int k = 0;k<gridDepth;k++){
					if(nodes[i,j,k].startingPoint){
						return nodes[i,j,k];
					}
				}
			}
		}
		return null;
	}
	public Node GetGoalNode(Node[,,]nodes){
		for(int i = 0;i<gridWidth;i++){
			for(int j=0;j<gridHeight;j++){
				for(int k = 0;k<gridDepth;k++){
					if(nodes[i,j,k].hasTarget){
						return nodes[i,j,k];
					}
				}
			}
		}
		return null;
	}

	public bool IsNodeAvailable(Node[,,] nodes, int x, int y, int z){
		if(x<gridWidth && y<gridHeight && z<gridDepth && x>=0 && y>=0 && z>=0 && nodes[x,y,z].traversable){
			return true;
		}
		else{
			return false;
		}
	}
	public Vector3 GetMatrixSize(){
		return new Vector3(gridWidth,gridHeight,gridDepth);
	}



	public void PaintNode(Node node, int materialType=0){
		node.GetComponent<MeshRenderer>().enabled = true;
		node.GetComponent<MeshRenderer>().material = nodeMaterials[materialType];
	}
}
