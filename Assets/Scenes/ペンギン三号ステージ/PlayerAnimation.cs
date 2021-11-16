using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayJump(float velY)
    {
        animator.SetFloat("Jump", velY);
    }
    public void Running(bool runnning)
    {
        animator.SetBool("Run", runnning);
    }
}
