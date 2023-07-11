using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    public float backSpeed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwards = Input.GetAxis("Vertical") * Time.deltaTime * Vector3.forward;

        if (forwards.magnitude > 0f)
        {
            forwards *= walkSpeed;
        }
        else
        {
            forwards *= backSpeed;
        }

        transform.Translate(forwards);

        float turning = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;

        transform.Rotate(0, turning, 0);
    }
}
