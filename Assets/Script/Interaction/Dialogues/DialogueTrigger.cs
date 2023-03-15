using UnityEngine;

/*
 * This script came from Brackeys tutorial on YouTube:
 * https://www.youtube.com/watch?v=_nRzoTzeyxU
 */
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool activated = false;
    
    public void TriggerDialogue()
    {
        if (activated) return;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        activated = true;
    }
}