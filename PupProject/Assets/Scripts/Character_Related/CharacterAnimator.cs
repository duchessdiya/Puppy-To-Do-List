using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    #region VARIABLES
    [Header("SerializeField")]
    [SerializeField]
    Animator animator;

    [Header("Constants")]
    public static string walkBool = "isWalking";
    public static string jumpBool = "isJumping";
    #endregion
    #region PUBLIC METHODS
    public void setWalk(bool isWalking)
    {
        animator.SetBool(walkBool, isWalking);
    }
    public void setJump(bool isJumping)
    {
        animator.SetBool(jumpBool, isJumping);
    }
    #endregion

}
