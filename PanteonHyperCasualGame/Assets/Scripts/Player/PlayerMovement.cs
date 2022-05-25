using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // VARIABLES
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 1f;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.81f;
    

   // REFERENCES
    private Animator animator;
    private Rigidbody rigidbody;
    private SwerveInput swerveInput;

    private void Awake() 
    {   
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        swerveInput = GetComponent<SwerveInput>();
    }
  
    private void FixedUpdate() 
    {
        if(GameManager.isPlaying)
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * swerveInput.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            animator.SetBool("isRunning",true);
            Vector3 verticalMove = transform.forward * verticalSpeed * Time.fixedDeltaTime;
            Vector3 horizontalMove = new Vector3(swerveAmount,0,0);
            rigidbody.MovePosition(rigidbody.position + verticalMove + horizontalMove);
        }
        else{
            animator.SetBool("isRunning",false);
        }  
    }
}

