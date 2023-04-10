using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimation : MonoBehaviour
{
    private Animator mAnimator;
    void Start()
    {
        Scene m_Scene = SceneManager.GetActiveScene();
        string sceneName = m_Scene.name;
        mAnimator = GetComponent<Animator>();
        if(sceneName == "TestPlanet1" && GlobalVariables.hasSeenMuseum){
            this.LaunchLaunchAnimation();
        } else {
            this.LaunchLandAnimation();
        }
    }

    public void LaunchLaunchAnimation()
    {
        Debug.Log("Launch animation started");
        mAnimator.Play("Launch");
    }

    public void LaunchLandAnimation()
    {
        Debug.Log("Land animation started");
        mAnimator.Play("Land");
    }

    // Update is called once per frame
}
