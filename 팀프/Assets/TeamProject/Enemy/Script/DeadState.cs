using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnemyState
{
    private Enemy enemy;

    public Transform target;
    public Vector3 direction;

    private Animator animator;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Dead State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
    }

    void EnemyState.Update()
    {
        animator.SetBool("isDead", true);
    }

    void EnemyState.OnExit()
    {
        animator.SetBool("isDead", false);
    }
}
