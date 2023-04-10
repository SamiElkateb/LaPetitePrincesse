using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Planet1Script : MonoBehaviour
{
    public void leaveMuseum(){
        GlobalVariables.hasSeenMuseum = true;
        SceneManager.LoadScene("TestPlanet1");
    }

    public void leavePlanet(){
        if(GlobalVariables.hasSeenMuseum){
            SceneManager.LoadScene("Planet2");
        }
    }

}