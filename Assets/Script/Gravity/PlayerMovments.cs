using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovments : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 moveDirection;
    void Update()
    {
        Debug.Log("Horizontal: " + Input.GetAxis("Horizontal"));
        Debug.Log("Vertical: " + Input.GetAxis("Vertical"));
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }
    
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
}
