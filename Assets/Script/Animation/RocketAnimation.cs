using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimation : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
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
