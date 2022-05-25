using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    //REFERENCES
    Rigidbody rigidbody;
    Animator animator;

    //Variables
    RaycastHit hit;
    Vector3 forwardMove;
    Vector3 horizontalMove;
    [SerializeField] private float moveSpeed;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        if(GameManager.isPlaying)
        {
            forwardMove = transform.forward * moveSpeed * Time.fixedDeltaTime;
            animator.SetBool("isRunning",true);
        // check forward
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z + 0.62f), transform.TransformDirection(Vector3.forward), out hit, 7f))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white);

            if (hit.collider.gameObject.tag != "OpponentHelper")
            {
                if (transform.position.x <= 0 && hit.collider.gameObject.transform.position.x <= 0) // obje sol char sol
                {
                    horizontalMove = transform.right * 1 * Time.fixedDeltaTime;
                    rigidbody.MovePosition(rigidbody.position + horizontalMove);
                }
                else if (transform.position.x > 0 && hit.collider.gameObject.transform.position.x > 0) // obje sağ char sağ
                {
                    horizontalMove = transform.right * -1 * Time.fixedDeltaTime;
                    rigidbody.MovePosition(rigidbody.position + horizontalMove);
                }
                else if (transform.position.x > 0 && hit.collider.gameObject.transform.position.x <= 0) // obje sol char sağ
                {
                    horizontalMove = transform.right * 1 * Time.fixedDeltaTime;
                    rigidbody.MovePosition(rigidbody.position + horizontalMove);
                }
                else          //object sağ char sol
                {
                    horizontalMove = transform.right * -1 * Time.fixedDeltaTime;
                    rigidbody.MovePosition(rigidbody.position + horizontalMove);
                }
            }
        }
        // check 45 degree right
        else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z + 0.62f), transform.TransformDirection(Quaternion.AngleAxis(45, transform.up) * transform.forward), out hit, 5f))
        {
            if (hit.collider.gameObject.tag != "OpponentHelper")
            {
                horizontalMove = transform.right * -1 * Time.fixedDeltaTime;
                rigidbody.MovePosition(rigidbody.position + horizontalMove);
            }
        }
        // check 45 degree left
        else if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z + 0.62f), transform.TransformDirection(Quaternion.AngleAxis(-45, transform.up) * transform.forward), out hit, 5f))
        {
            if (hit.collider.gameObject.tag != "OpponentHelper")
            {
                Vector3 horizontalMove = transform.right * 1 * Time.fixedDeltaTime;
                rigidbody.MovePosition(rigidbody.position + horizontalMove);
            }
        }
        rigidbody.MovePosition(rigidbody.position + forwardMove);
        }
        else{
            animator.SetBool("isRunning",false);
        }
        
    }
}
