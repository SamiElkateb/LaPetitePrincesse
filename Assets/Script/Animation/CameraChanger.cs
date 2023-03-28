using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    
    private Camera mMainCamera;
    private Camera mRocketCamera;
    private PlayerMovement mPlayerMovement;
    
    private void Start()
    {
        mMainCamera = FindObjectOfType<MainCamera>().GetComponent<Camera>();
        mRocketCamera = FindObjectOfType<RocketCamera>().GetComponent<Camera>();
        mPlayerMovement = FindObjectOfType<PlayerMovement>();
    }
    
    public void ChangeToRocketCamera()
    {
        Debug.Log("Change to rocket camera");
        mMainCamera.enabled = false;
        mRocketCamera.enabled = true;
        mPlayerMovement.enabled = false;
    }
    
    public void ChangeToMainCamera()
    {
        Debug.Log("Change to main camera");
        mMainCamera.enabled = true;
        mRocketCamera.enabled = false;
        mPlayerMovement.enabled = true;
    }
}