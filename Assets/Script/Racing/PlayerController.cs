using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private Vector2 vect;
    public UnityEvent<Vector2> onInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
       void Update() // Get keyboard inputs
   {
       inputY = Input.GetAxis("Vertical");
       inputX = Input.GetAxis("Horizontal");
       vect = new Vector2(inputX, inputY).normalized;
       onInput.Invoke(vect);
   }

    
}
