using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<ThirdPersonCam>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
