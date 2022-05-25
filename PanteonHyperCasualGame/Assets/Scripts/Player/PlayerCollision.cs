using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    private Rigidbody rigidbody;
    private Vector3 startPos;
    private bool addforce = false;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject rankPanel;

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;
        wall.SetActive(false);
    }
    private void FixedUpdate() 
    {
        if(addforce)
        {
            if(transform.position.x >= 0)
            {
                rigidbody.AddForce(Vector3.left * 15f, ForceMode.Acceleration);
            }
            else
            {
                rigidbody.AddForce(Vector3.left * 5f, ForceMode.Acceleration);
            }

        }
    }
   private void OnCollisionEnter(Collision other) {
       //transform.parent = platform.transform;
       if(other.transform.tag == "RotatingPlatform")
       {
           addforce=true;
       }
       else if(other.transform.tag == "Obstacle")
       {
           transform.position = startPos;
       }
       else if(other.transform.tag == "Finish")
       {
           GameManager.isPlaying = false; 
           rankPanel.SetActive(false);
           finishPanel.SetActive(true); 
           wall.SetActive(true);
       }
   }
   private void OnCollisionExit(Collision other) {
       //transform.parent = platform.transform;
       if(other.transform.tag == "RotatingPlatform")
       {
           addforce=false;
       }
   }
}
