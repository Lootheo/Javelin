using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITargetFollow : MonoBehaviour
{
    public List<Image> allImages;
    public List<Image> enabledImages;
    public List<GameObject> targets;
    public Camera UI_Cam;


    private static UITargetFollow instance = null;


    public static UITargetFollow GetInstance()
    {
        if (instance == null)
        {
            instance = new UITargetFollow();
        }

        return instance;
    }

    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                Vector2 uiPos = UI_Cam.WorldToScreenPoint(targets[i].transform.position);
                //Vector2 uiPos = RectTransformUtility.WorldToScreenPoint(UI_Cam, targets[i].transform.position);
                enabledImages[i].rectTransform.anchoredPosition = new Vector2(uiPos.x - (Screen.width / 2), uiPos.y - (Screen.height / 2));
            }
        }
    }

    public void AddToTargets(GameObject target)
    {
        targets.Add(target);
    }

    public void RemoveTargets(GameObject target)
    {
        targets.Remove(target);
    }


}
