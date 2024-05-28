using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private static readonly int isWalking = Animator.StringToHash("isWalking");

    private readonly float magnituteThreshold = 0.5f;

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
}
