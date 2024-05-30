using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isRunning = Animator.StringToHash("isRunning");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMoveAnim()
    {
        animator.SetBool(isWalking, true);
    }

    public void OutMoveAnime()
    {
        animator.SetBool(isWalking, false);
    }

    public void OnRunAnim()
    {
        animator.SetBool(isRunning, true);
    }

    public void OutRunAnime()
    {
        animator.SetBool(isRunning, false);
    }
}
