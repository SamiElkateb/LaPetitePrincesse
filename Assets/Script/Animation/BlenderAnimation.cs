using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderAnimation : MonoBehaviour
{
    private Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mAnimator.enabled = false;
    }

    public void StartAnimation()
    {
        mAnimator.enabled = true;
    }

    public void StopAnimation()
    {
        mAnimator.enabled = false;
    }
}
