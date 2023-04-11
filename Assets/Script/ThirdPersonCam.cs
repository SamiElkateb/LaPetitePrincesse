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
    
    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;
    public GameObject target;

    
    public float rotationSpeed;
    
    public Transform cam;
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
    float horizontalInputMouse = Input.GetAxis("Mouse X") * rotationSpeed;

    Vector3 rotationVector = new Vector3(0, horizontalInputMouse, 0);

    transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime, Space.Self);

    // playerGameObject.transform.rotation = Camera.main.transform.rotation;

    // GameObject player = FindObjectOfType<Player>().gameObject;
    // player.transform.LookAt(new Vector3(target.transform.position.x, player.transform.position.y, player.transform.position.z));
        // Transform selfTransform = player.transform;
        //  float distanceToPlane = Vector3.Dot(selfTransform.up, target.transform.position - selfTransform.position);
        //  Vector3 pointOnPlane = target.transform.position - (selfTransform.up * distanceToPlane);
        //  Debug.Log(pointOnPlane.x);
        //  selfTransform.LookAt(pointOnPlane, selfTransform.up);

        // float distanceToPlane = Vector3.Dot(selfTransform.up, position - selfTransform.position);
        //  Vector3 pointOnPlane = position - (selfTransform.up * distanceToPlane);
        //  selfTransform.LookAt(pointOnPlane, selfTransform.up);

    }
    
    void FixedUpdate(){
        // Transform selfTransform = player.transform;
        // float distanceToPlane = Vector3.Dot(selfTransform.up, target.transform.position - selfTransform.position);
        // Vector3 pointOnPlane = target.transform.position - (selfTransform.up * distanceToPlane);
        // Debug.Log(pointOnPlane.x);
        // //  selfTransform.LookAt(pointOnPlane, selfTransform.up);
        // float speed = 10f;
        // Vector3 direction = target.transform.position - selfTransform.position;
        // Quaternion toRotation = Quaternion.FromToRotation(selfTransform.forward, pointOnPlane);
        // transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.time);
        // Vector3 direction = target.transform.position - transform.position;
        // direction.y = 0; // Ignore vertical (Y) direction to only rotate on local axis
        // rotationSpeed = 1.0f;

        // // Rotate the player to face the camera direction
        // if (direction.magnitude > 0.1f) // Only rotate if there is a significant direction
        // {
        //     Quaternion rotation = Quaternion.LookRotation(direction);
        //     transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        // }
    }
}