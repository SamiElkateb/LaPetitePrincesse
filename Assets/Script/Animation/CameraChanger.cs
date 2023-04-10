using Unity.VisualScripting;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    
    private Camera mMainCamera;
    private Camera mRocketCamera;
    private PlayerMovement mPlayerMovement;
    private GameObject playerGameObject;
    
    private void Start()
    {
        mMainCamera = FindObjectOfType<MainCamera>().GetComponent<Camera>();
        mRocketCamera = FindObjectOfType<RocketCamera>().GetComponent<Camera>();
        mPlayerMovement = FindObjectOfType<PlayerMovement>();
        playerGameObject = FindObjectOfType<Player>().gameObject;
        MeshRenderer[] meshRenderers = playerGameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].enabled = false;
        }
        SkinnedMeshRenderer[] skinnedRenderers = playerGameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < skinnedRenderers.Length; i++)
        {
            skinnedRenderers[i].enabled = false;
        }
    }
    
    public void ChangeToRocketCamera()
    {
        Debug.Log("Change to rocket camera");
        mMainCamera.enabled = false;
        mRocketCamera.enabled = true;
        mPlayerMovement.enabled = false;
        MeshRenderer[] meshRenderers = playerGameObject.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].enabled = true;
        }
        SkinnedMeshRenderer[] skinnedRenderers = playerGameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < skinnedRenderers.Length; i++)
        {
            skinnedRenderers[i].enabled = true;
        }
    }
    
    public void ChangeToMainCamera()
    {
        Debug.Log("Change to main camera");
        mMainCamera.enabled = true;
        mRocketCamera.enabled = false;
        mPlayerMovement.enabled = true;
        playerGameObject.SetActive(true);
    }
}