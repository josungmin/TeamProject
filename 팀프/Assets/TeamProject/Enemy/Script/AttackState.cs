using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackState : EnemyState
{
    private Enemy enemy;
    private Animator animator;

    void EnemyState.OnEnter(Enemy enemy)
    {
        SceneManager.LoadScene("BattleScene");

        Debug.Log("Attack State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();

    }

    void EnemyState.Update()
    {
        //animator.SetBool("isAttack", true);
    }

    void EnemyState.OnExit()
    {
        //animator.SetBool("isAttack", false);
    }
}
