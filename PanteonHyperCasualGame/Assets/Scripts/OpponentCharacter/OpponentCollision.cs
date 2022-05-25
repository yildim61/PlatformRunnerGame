using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCollision : MonoBehaviour
{
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter(Collision other) {
       //transform.parent = platform.transform;
       if(other.transform.tag == "Obstacle")
       {
           transform.position = startPos;
       }
   }
   private void OnCollisionExit(Collision other) 
   {
      
   }
}
