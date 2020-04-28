using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_DeadState : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Dead State");
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();
    }

    void DragonState.Update()
    {
        animator.SetBool("isDead", true);
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isDead", false);
    }
}
