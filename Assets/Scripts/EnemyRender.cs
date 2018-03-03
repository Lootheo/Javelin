using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRender : MonoBehaviour
{
    public Renderer rend;
    public bool rendering;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnWillRenderObject()
    {
        if (rendering)
        {
            return;
        }
        if (Camera.current.name == "AimCamera")
        {
            Debug.Log("Rendering Object");
            rendering = true;
            UITargetFollow.GetInstance().AddToTargets(transform.root.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        rendering = false;
        UITargetFollow.GetInstance().RemoveTargets(transform.root.gameObject);
    }

    /*void OnBecameVisible()
    {
        enabled = true;
    }*/
}
