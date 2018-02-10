using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{

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

    IEnumerator FindPath()
    {
        yield return new WaitForSeconds(0.3f);

        Node startNode = nodeManager.GetStartingNode(nodes);
        Node goalNode = nodeManager.GetGoalNode(nodes);
        //The set of nodes already evaluated
        List<Node> closedList = new List<Node>();
        // The set of currently discovered nodes that are not evaluated yet.
        // Initially, only the start node is known.
        List<Node> openList = new List<Node>();
        openList.Add(startNode);

        startNode.gScore = 0;
        startNode.fScore = Vector3.Distance(transform.position, nodeManager.target.position);

        while (openList.Count > 0)
        {
            Node currentNode = openList[0];
            if (currentNode == goalNode)
            {
                ReconstructPath(currentNode.previousNode, currentNode);
                break;
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);
            nodeManager.PaintNode(currentNode, 4);
            Vector3 nodePosition = nodeManager.GetNodePosition(nodes, currentNode);


            List<Node> neighbors = nodeManager.GetAdjacentNodes(nodes, (int)nodePosition.x, (int)nodePosition.y, (int)nodePosition.z);
            foreach (Node neighbor in neighbors)
            {
                if (closedList.Contains(neighbor))
                {   // Ignore the neighbor which is already evaluated.
                    continue;
                }
                if (!openList.Contains(neighbor))
                {
                    yield return null;
                    //nodeManager.PaintNode(neighbor,0);
                    openList.Add(neighbor);
                }

                // The distance from start to a neighbor
                //the "distance" function may vary as per the solution requirements.
                float tentative_gScore = currentNode.gScore + Vector3.Distance(currentNode.transform.position, neighbor.transform.position);

                if (tentative_gScore >= neighbor.gScore)
                {    // This is not a better path.
                    continue;
                }
                neighbor.previousNode = currentNode;
                // This path is the best until now. Record it!
                neighbor.gScore = tentative_gScore;
                neighbor.fScore = neighbor.gScore + Vector3.Distance(neighbor.transform.position, goalNode.transform.position);
            }
            openList.Sort(delegate (Node a, Node b)
                {
                    return a.fScore
                   .CompareTo(
                       b.fScore);
                });
        }
    }


    List<Node> ReconstructPath(Node cameFrom, Node currentNode)
    {
        List<Node> totalPath = new List<Node>();
        while (currentNode != null)
        {
            totalPath.Add(currentNode);
            nodeManager.PaintNode(currentNode, 3);
            currentNode = currentNode.previousNode;
        }
        totalPath.Reverse();
        GetComponent<PathFollow>().StartPath(totalPath);
        return totalPath;
    }
}
