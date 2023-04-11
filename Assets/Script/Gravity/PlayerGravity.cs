using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGravity : MonoBehaviour
{
    
    public  PlanetScript attractor;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Scene m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;
        if(sceneName == "Planet2"){
            rb.useGravity = true;
        } else
        {
            rb.useGravity = false;
        }
        
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
