using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorMovement : MonoBehaviour
{
    float magicNumberLR = 1.5f;
    float magicNumberUD = 0.9f;

    float anotherMagicNumber = 5;

    //why? fuck you, that's why.

    bool moving = false;

    public SelectMode currentMode, newMode;

    Vector3 home, away; //closer each day

    // Start is called before the first frame update
    void Start()
    {
        currentMode = SelectMode.Central;
        newMode = SelectMode.Central;
        home = transform.localPosition;
        away = home;
    }

    // Update is called once per frame
    void Update()
    {
        if (newMode != currentMode)
        {
            switch (newMode)
            {
                case SelectMode.Central:
                    away = home;
                    Debug.Log('s');
                    break;
                case SelectMode.West:
                    away = home - new Vector3(magicNumberLR, 0, 0);
                    break;
                case SelectMode.North:
                    away = home + new Vector3(0, magicNumberUD, 0);
                    break;
                case SelectMode.East:
                    away = home + new Vector3(magicNumberLR, 0, 0);
                    break;
                case SelectMode.South:
                    away = home - new Vector3(0, magicNumberUD, 0);
                    break;
                default:
                    Debug.LogError(newMode);
                    break;
            }

            currentMode = newMode;
        }

        if (away != transform.localPosition)
        {
            transform.Translate(Vector3.Normalize(away - transform.localPosition) * anotherMagicNumber * Time.deltaTime);
        }
    }
}

