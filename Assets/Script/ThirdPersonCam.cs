using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Transform movementDir;
    public Rigidbody rb;
    
    public float rotationSpeed;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
//     void Update()
//     {

//         // Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
//         // orientation.forward = viewDir.normalized;

//         // float horizontal = Input.GetAxis("Horizontal");
//         // float vertical = Input.GetAxis("Vertical"); 
//         // Vector3 inputDir = orientation.forward * vertical + orientation.right * horizontal;
        
//         // if(inputDir != Vector3.zero){
//         //     // playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
//         //     playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
//         //     movementDir.position = player.position + inputDir.normalized;
//         // }
//         // Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
//         // if (moveDirection != Vector3.zero) { // only update target rotation when moving
//         //     Quaternion targetRotation = Quaternion.LookRotation(moveDirection, transform.up);
//         //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); // rotate towards target rotation
//         // }



// Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
// if (moveDirection != Vector3.zero) { // only update target rotation when moving
//     Quaternion targetRotation = Quaternion.LookRotation(moveDirection, transform.up);

//     // Calculate new rotation angles based on target direction
//     Vector3 targetAngles = Quaternion.LookRotation(targetRotation * Vector3.forward, Vector3.up).eulerAngles;
//     Vector3 currentAngles = playerObj.rotation.eulerAngles;
//     targetAngles.x = currentAngles.x; // Lock the X-axis rotation
//     Quaternion newRotation = Quaternion.Euler(targetAngles);

//     // Interpolate towards the new rotation
//     playerObj.rotation = Quaternion.Lerp(playerObj.rotation, newRotation, Time.deltaTime * rotationSpeed);
// }
// }
void Update() {
    // Get keyboard input
    float horizontalInput = Input.GetAxis("Horizontal");
    // float verticalInput = Input.GetAxis("Vertical");

    // Construct rotation vector based on keyboard input
    Vector3 rotationVector = new Vector3(0, horizontalInput, 0);

    // Rotate the object around its local Y and X axes based on rotation vector
    transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime, Space.Self);
}
}