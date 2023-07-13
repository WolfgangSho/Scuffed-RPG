using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    /// what da cursor doin?

    public CursorLockMode lockState;
    public bool isCursorVisible;
    public float minMouseDistance, maxMouseDistance;

    public SelectorMovement leftSelectionMover, rightSelectionMover;

    public SelectMode selection;

    Vector3 centrePosition, currentPosition;

    float xDif, yDif, xAbs, yAbs;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = lockState;
        Cursor.visible = isCursorVisible;

        centrePosition = Input.mousePosition;
        currentPosition = centrePosition;

        changeSelection(SelectMode.Central);

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Input.mousePosition;

        xDif = currentPosition.x - centrePosition.x;
        yDif = currentPosition.y - centrePosition.y;

        xAbs = Mathf.Abs(xDif);
        yAbs = Mathf.Abs(yDif);


        if (xAbs > minMouseDistance && xAbs > yAbs)
        {
            if (xDif > 0)
            {
                changeSelection(SelectMode.East);

                if (xAbs > maxMouseDistance)
                {
                    centrePosition.x -= maxMouseDistance - xAbs;
                }
            }
            else
            {
                changeSelection(SelectMode.West);

                if (xAbs > maxMouseDistance)
                {
                    centrePosition.x += maxMouseDistance - xAbs;
                }
            }
        }
        else if (yAbs > minMouseDistance && yAbs > xAbs)
        {
            if (yDif > 0)
            {
                changeSelection(SelectMode.North);

                if (yAbs > maxMouseDistance)
                {
                    centrePosition.y -= maxMouseDistance - yAbs;
                }
            }
            else
            {
                changeSelection(SelectMode.South);

                if (yAbs > maxMouseDistance)
                {
                    centrePosition.y += maxMouseDistance - yAbs;
                }
            }
        }
        else
        {
            changeSelection(SelectMode.Central);

        }

    }

    void changeSelection(SelectMode newSelection)
    {
        if (selection != newSelection)
        {
            selection = newSelection;

            leftSelectionMover.newMode = selection;
            rightSelectionMover.newMode = selection;
            Debug.Log(selection);
        }
    }
}

public enum SelectMode
{
    Error,
    West,
    North,
    East,
    South,
    Central
}
