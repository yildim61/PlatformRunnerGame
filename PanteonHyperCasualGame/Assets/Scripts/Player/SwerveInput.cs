using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInput : MonoBehaviour
{
     private float lastFingerPositionX;
    private float moveX;
    public float MoveFactorX => moveX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveX = Input.mousePosition.x - lastFingerPositionX;
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveX = 0f;
        }
    }
}
