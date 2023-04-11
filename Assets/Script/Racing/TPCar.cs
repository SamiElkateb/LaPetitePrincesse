using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCar : MonoBehaviour
{
    
    public Vector3 initialPosition;
    public Vector3 initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetInitialPosition()
    {
        gameObject.transform.position = initialPosition;
        gameObject.transform.rotation = Quaternion.Euler(initialRotation);
    }
    
    
}
