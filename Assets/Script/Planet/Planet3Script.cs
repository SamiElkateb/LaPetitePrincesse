using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet3Script : MonoBehaviour
{
    // Start is called before the first frame update
    
    private List<CreatureGlobalScript> creatures;
    private Interactable rocketLauncherInteractable;
    private Interactable endDialogueInteractable;
    void Start()
    {

        // Set the sky as day
        GameObject[] skys = GameObject.FindGameObjectsWithTag("Sky");
        for (int i = 0; i < skys.Length; i++)
        {
            skys[i].GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.1f, 0));
        }

        // Desactivate the possibility to interact with the rocket launcher
        rocketLauncherInteractable = GameObject.Find("RocketLauncher").GetComponent<Interactable>();
        rocketLauncherInteractable.Desactivate();
        
        // Desactivate the possibility to interact with the end Dialogue
        endDialogueInteractable = GameObject.Find("EndDialogue").GetComponent<Interactable>();
        endDialogueInteractable.Desactivate();
        
        // Desactivate all interactions with the creatures
        creatures = new List<CreatureGlobalScript>();
        CreatureGlobalScript[] creaturesFound = FindObjectsOfType<CreatureGlobalScript>();
        foreach (var creature in creaturesFound)
        {
            Debug.Log(creature);
            
            if (creature.GetComponent<Interactable>() != null)
            {
                Debug.Log("Interactable found" + creature.name);
                creature.GetComponent<Interactable>().Desactivate();
                creatures.Add(creature);
            }
        }
    }

    public void HideAllCreatures()
    {
        Debug.Log("Hidding all creatures");
        foreach (var creature in creatures)
        {
            creature.GetComponent<Interactable>().Activate();
            creature.teleportToHiddenPosition();
        }
    }
    
    public void AllCreaturesDiscovered()
    {
        Debug.Log("All creatures discovered in Planet 3 Script");
        endDialogueInteractable.Activate();
    }

    public void ActivateRocketLauncher()
    {
        Debug.Log("Activating rocket launcher");
        rocketLauncherInteractable.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
