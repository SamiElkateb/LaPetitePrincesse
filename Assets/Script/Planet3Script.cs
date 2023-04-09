using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet3Script : MonoBehaviour
{
    // Start is called before the first frame update
    
    private List<CreatureGlobalScript> creatures;
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
