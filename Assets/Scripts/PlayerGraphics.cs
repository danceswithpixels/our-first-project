using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void setPlayerAnimation(string playerAnimationDescription, bool playerAnimationValue) {
        animator.SetBool(playerAnimationDescription, playerAnimationValue);
    }
}
