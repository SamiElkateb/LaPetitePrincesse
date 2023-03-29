using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CreatureDialogue: MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    private HideAndSeekManager hideAndSeekManager;
    private OnCreature onCreature;

    public void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        onCreature = GetComponent<OnCreature>();
        hideAndSeekManager = FindObjectOfType<HideAndSeekManager>();
    }
    
    public void onInteract()
    {
        UnityEvent unityEvent = new UnityEvent();
        unityEvent.AddListener(hideAndSeekManager.CheckIfAllCreaturesDiscovered);
        dialogueTrigger.TriggerDialogue(unityEvent);
        Debug.Log("Creature name is: " + onCreature.creatureName);
        hideAndSeekManager.CreatureDiscovered(onCreature.creatureName);
        // hideAndSeekManager.CheckIfAllCreaturesDiscovered();
        // Need to TP the creature at the ned of the dialogue
    }
    
    public void onEndDialogue()
    {
        Debug.Log("End of dialogue");
    }
}