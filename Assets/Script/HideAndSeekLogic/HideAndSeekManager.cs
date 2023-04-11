using System;
using TMPro;
using UnityEngine;

public class HideAndSeekManager: MonoBehaviour
{
    public string[] creaturesNameToDiscover;
    private bool[] creaturesDiscovered;
    public Dialogue dialogueAllCreaturesDiscovered;
    public Planet3Script planet3Script;
    private TextMeshProUGUI _textCreatureDiscovered;
    private int _creaturesFound = 0;

    public void Start()
    {
        creaturesDiscovered = new bool[creaturesNameToDiscover.Length];
        planet3Script = GameObject.Find("GlobalManager").GetComponent<Planet3Script>();
        _textCreatureDiscovered = GameObject.Find("CreaturesFound").GetComponent<TextMeshProUGUI>();
        _textCreatureDiscovered.enabled = false;
    }
    
    public void StartHideAndSeek()
    {
        Debug.Log("Start Hide and Seek");
        _textCreatureDiscovered.enabled = true;
        _updateTextCreaturesFound();
    }

    public void CreatureDiscovered(string creatureNameDiscovered)
    {
        Debug.Log("Creature discovered: " + creatureNameDiscovered);
        _creaturesFound++;
        _updateTextCreaturesFound();
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
        
        // Desactivate Text UI
        _textCreatureDiscovered.enabled = false;
        
        // Trigger dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueAllCreaturesDiscovered);
        
        // Call the methode in Planet3Script
        planet3Script.AllCreaturesDiscovered();
    }

    private void _updateTextCreaturesFound()
    {
        _textCreatureDiscovered.text = $"Creatures trouvees: {_creaturesFound}/{creaturesNameToDiscover.Length}";
    }
}