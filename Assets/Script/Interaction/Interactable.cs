using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public float interactionRange = 0.5f;
    public UnityEvent onInteract;
    public UnityEvent onInteractEnd;
    public bool isInteractable = true;

    public void Start()
    {
        Activate();
    }
    
    public void OnTriggerEnter(Collider other)
    {
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
    
    public void Activate()
    {
        isInteractable = true;
        SphereCollider sc = gameObject.AddComponent<SphereCollider>();
        sc.radius = interactionRange;
        sc.isTrigger = true;
    }
    
    public void Desactivate()
    {
        isInteractable = false;
        Destroy(gameObject.GetComponent<SphereCollider>());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}