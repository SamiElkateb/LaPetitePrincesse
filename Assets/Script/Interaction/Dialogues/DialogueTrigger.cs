using System;
using UnityEngine;
using UnityEngine.Events;

/*
 * This script came from Brackeys tutorial on YouTube:
 * https://www.youtube.com/watch?v=_nRzoTzeyxU
 */
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool activated = false;
    private UnityEvent onInteract;
    public void Start()
    {
    }

    public void TriggerDialogue()
    {
        if (activated) return;
        desactivateComponents();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        activated = true;
    }
    public void TriggerDialogue(UnityEvent unityEvent)
    {
        if (activated) return;
        desactivateComponents();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, unityEvent);
        activated = true;
    }

    private void desactivateComponents()
    {
        Debug.Log("Desactivate components");
        pressKey pressKey = GetComponent<pressKey>();
        pressKey.OnExit();
        GetComponent<SphereCollider>().isTrigger = false;
        pressKey.enabled = false;
        GetComponent<Interactable>().enabled = false;
    }
}