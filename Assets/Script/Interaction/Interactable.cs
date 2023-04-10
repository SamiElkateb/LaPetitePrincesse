using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class Interactable : MonoBehaviour
{
    public float interactionRange = 0.5f;
    public UnityEvent onInteract;
    public UnityEvent onInteractEnd;
    public bool isInteractable = true;
    private SphereCollider _sphereCollider;

    public void Start()
    {
        Initialization();
        Activate();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("on Enter " + gameObject.name);
            if (other.gameObject.GetComponent<Player>() != null)
            {
                onInteract.Invoke();
                Debug.Log("Player entered interactable range");
                /*
                InteractionPromptUI ui = other.gameObject.GetComponent<Player>().interactionPromptUI;
                ui.SetUp("Player entered interactable range");
                Debug.Log("Player entered interactable range");
                */
            }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("on Exit " + gameObject.name);
        if (other.gameObject.GetComponent<Player>() != null)
        {
            onInteractEnd.Invoke();
            Debug.Log("Player exited interactable range");
            /*
            InteractionPromptUI ui = other.gameObject.GetComponent<Player>().interactionPromptUI;
            ui.SetUp("Player exited interactable range");
            Debug.Log("Player exited interactable range");
            */
        }
    }

    private void Initialization()
    {
        _sphereCollider = gameObject.AddComponent<SphereCollider>();
        _sphereCollider.radius = interactionRange;
        _sphereCollider.isTrigger = true;
        _sphereCollider.enabled = false;
        isInteractable = false;
        
    }
    
    public void Activate()
    {
        isInteractable = true;
        _sphereCollider.enabled = true;
    }
    
    public void Desactivate()
    {
       isInteractable = false;
       _sphereCollider.enabled = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}