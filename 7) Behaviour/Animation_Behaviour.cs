using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Behaviour : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Change_Animation(string animation)
    {
        animator.SetTrigger(animation);
    }
}