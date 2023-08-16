using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelectionManager : MonoBehaviour
{
    public GameObject targetObject;
    public int hideDelay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hideDelay > 0)
        {
            hideDelay--;
        }
        else
        {
            targetObject.SetActive(false);
        }

    }

    public void ShowTarget()
    {
        hideDelay = 10;
        targetObject.transform.LookAt(Camera.main.transform.position);
        targetObject.SetActive(true);
    }
}
