using UnityEngine;

/*
 * This script came from Brackeys tutorial on YouTube:
 * https://www.youtube.com/watch?v=_nRzoTzeyxU
 */
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}