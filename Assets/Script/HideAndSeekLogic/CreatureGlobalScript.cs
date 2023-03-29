using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CreatureGlobalScript: MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    private HideAndSeekManager hideAndSeekManager;
    private OnCreature onCreature;
    private Teleport teleport;
    public Vector3 teleportPosition;
    
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
        unityEvent.AddListener(() => teleport.TeleportToPosition(teleportPosition));
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