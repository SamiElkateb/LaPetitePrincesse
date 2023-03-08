using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    
    public  PlanetScript attractor;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        
        // Pour l'instant, il n'y a pas de rotation
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerTransform = transform;
    }
    
    private void FixedUpdate()
    {
        if (attractor) {
            attractor.Attract(playerTransform);
        }
    }
}
