using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRayCast : MonoBehaviour
{
    LayerMask mask;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Target");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask))
        {
            hit.transform.GetComponent<TargetSelectionManager>().ShowTarget();
        }
    }
}
