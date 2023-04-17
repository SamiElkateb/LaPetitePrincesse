using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Planet1Script : MonoBehaviour
{
    void Start(){
        // Set the sky as night
        GameObject[] skys = GameObject.FindGameObjectsWithTag("Sky");
        for (int i = 0; i < skys.Length; i++)
        {
            skys[i].GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.32f, 0));
        }
    }
    public void leaveMuseum(){
        GlobalVariables.hasSeenMuseum = true;
        SceneManager.LoadScene("Planet1");
    }

    public void leavePlanet(){
        if(GlobalVariables.hasSeenMuseum){
            SceneManager.LoadScene("Planet2");
        }
    }

}
