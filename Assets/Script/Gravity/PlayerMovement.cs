using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed;
    private Vector3 moveDirection;
    

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
        Debug.Log("Vertical: " + Input.GetAxis("Vertical"));
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }
    
    void FixedUpdate()
    {
        if(moveDirection != Vector3.zero)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
