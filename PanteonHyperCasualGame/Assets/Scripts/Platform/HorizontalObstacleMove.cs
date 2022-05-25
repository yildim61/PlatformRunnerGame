using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMove : MonoBehaviour
{
   private bool moveBack;
   [SerializeField] float moveSpeed;
   Vector3 baseTransform;
   public float moveLimit = 0.15f;
   private void Start()
   {
       baseTransform = transform.localPosition;
   }

    void Update()
    {
        if (transform.localPosition.x >= baseTransform.x + moveLimit)
            moveBack = true;

        if (transform.localPosition.x < baseTransform.x - moveLimit)
            moveBack = false;
    }

    private void FixedUpdate()
    {
        if (moveBack)
            transform.localPosition += new Vector3(-0.0085f*moveSpeed, 0, 0);
        else
            transform.localPosition += new Vector3(0.0085f*moveSpeed, 0, 0);           
    }

}
