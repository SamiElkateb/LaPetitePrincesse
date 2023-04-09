using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class CreatureGlobalScript: MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    private HideAndSeekManager hideAndSeekManager;
    private OnCreature onCreature;
    private Teleport teleport;
    public Vector3 hiddenPosition;
    public Vector3 initialPosition;
    
    public void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        onCreature = GetComponent<OnCreature>();
        hideAndSeekManager = FindObjectOfType<HideAndSeekManager>();
        teleport = GetComponent<Teleport>();
    }
    
    public void onInteract()
    {
        UnityEvent unityEvent = new UnityEvent();
        unityEvent.AddListener(() => teleport.TeleportToPosition(initialPosition));
        unityEvent.AddListener(hideAndSeekManager.CheckIfAllCreaturesDiscovered);
        dialogueTrigger.TriggerDialogue(unityEvent);
        Debug.Log("Creature name is: " + onCreature.creatureName);
        hideAndSeekManager.CreatureDiscovered(onCreature.creatureName);
        // hideAndSeekManager.CheckIfAllCreaturesDiscovered();
        // Need to TP the creature at the ned of the dialogue
    }
    
    public void teleportToHiddenPosition()
    {
        Debug.Log("Teleporting to hidden position");
        teleport.TeleportToPosition(hiddenPosition);
    }
    
    public void onEndDialogue()
    {
        Debug.Log("End of dialogue");
    }
}