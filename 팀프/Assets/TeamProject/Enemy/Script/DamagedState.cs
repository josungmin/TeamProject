using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : EnemyState
{
    private Enemy enemy;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Damaged State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        enemyinfo = enemy.GetComponent<EnemyInfo>();
        
        enemyinfo.p_HP = enemyinfo.c_HP;
        
    }

    void EnemyState.Update()
    {
        animator.SetBool("isDamaged", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        /*
        if (enemyinfo.p_HP <= 0)
        {
            enemy.SetState(new DeadState());
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Damaged 0") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            // 실행할것 구현
            if (distance >= enemy.IdleRange)
            {
                enemy.SetState(new IdleState());
            }
            // 실행할것 구현
            if (enemy.AttackRange <= distance && distance <= enemy.IdleRange)
            {
                enemy.SetState(new MoveState());
            }
            else if (enemy.AttackRange >= distance)
            {
                enemy.SetState(new AttackState());
            }
        }
        */
    }

    void EnemyState.OnExit()
    {
        animator.SetBool("isDamaged", false);
    }
}
