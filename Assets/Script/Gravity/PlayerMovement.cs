using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed;
    private Vector3 moveDirection;
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
        // if (moveDirection != Vector3.zero) { // only update target rotation when moving
        //     targetRotation = Quaternion.LookRotation(moveDirection, transform.up);
        // }
    }
    
    void FixedUpdate()
    {
        if (moveDirection != Vector3.zero)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); // rotate towards target rotation
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}