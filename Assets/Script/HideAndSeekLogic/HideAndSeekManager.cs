using System;
using UnityEngine;

public class HideAndSeekManager: MonoBehaviour
{
    public string[] creaturesNameToDiscover;
    private bool[] creaturesDiscovered;
    public Dialogue dialogueAllCreaturesDiscovered;
    public Planet3Script planet3Script;

    public void Start()
    {
        creaturesDiscovered = new bool[creaturesNameToDiscover.Length];
        planet3Script = GameObject.Find("GlobalManager").GetComponent<Planet3Script>();
    }

    public void CreatureDiscovered(string creatureNameDiscovered)
    {
        Debug.Log("Creature discovered: " + creatureNameDiscovered);
        foreach (string creatureName in creaturesNameToDiscover)
        {
            if (creatureName == creatureNameDiscovered)
            {
                Debug.Log("Creature found in the list");
                creaturesDiscovered[Array.IndexOf(creaturesNameToDiscover, creatureName)] = true;
            }
        }
    }
    
    public void CheckIfAllCreaturesDiscovered()
    {
        foreach (bool creatureDiscovered in creaturesDiscovered)
        {
            if (!creatureDiscovered)
            {
                return;
            }
        }
        Debug.Log("All creatures discovered");
        
        // Trigger dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueAllCreaturesDiscovered);
        
        // Call the methode in Planet3Script
        planet3Script.AllCreaturesDiscovered();
    }
}