using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed;
    public float runMultiplicator = 2f;
    private Vector3 moveDirection;
    private bool isRunning;
    private Quaternion targetRotation; // added variable to store target rotation
    public float rotationSpeed;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        targetRotation = transform.rotation; // initialize target rotation to current rotation
    }
    
    void Update()
    {
        //Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
        //Debug.Log("Vertical: " + Input.GetAxis("Vertical"));
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            isRunning = false;
        }
        // if (moveDirection != Vector3.zero) { // only update target rotation when moving
        //     targetRotation = Quaternion.LookRotation(moveDirection, transform.up);
        // }
    }
    
    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            float calcMoveSpeed = isRunning ? moveSpeed * runMultiplicator : moveSpeed;
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * calcMoveSpeed * Time.deltaTime);
            if(isRunning){
                animator.SetBool("isRunning", true);
                Debug.Log("IsRunning");
            } else {
                animator.SetBool("isRunning", false);
                Debug.Log("IsNotRunning");
            } 
            animator.SetBool("isMoving", true);
            // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); // rotate towards target rotation
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}