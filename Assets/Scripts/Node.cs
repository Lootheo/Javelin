using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool traversable = true;
    public bool hasTarget = false;
    public bool startingPoint = false;

    public float fScore = 10000;
    public float gScore = 10000;

    public Node previousNode = null;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Obstacle")
        {
            traversable = false;
            FindObjectOfType<NodeManager>().PaintNode(this, 2);
            gameObject.name = "obstaclenode";
        }
        else if (other.gameObject.tag == "Target")
        {
            hasTarget = true;
            traversable = true;
        }
        else if (other.gameObject.name == "Missile")
        {
            startingPoint = true;
        }
    }
}
