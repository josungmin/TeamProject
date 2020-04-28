using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    private Enemy enemy;

    public Transform target;
    public Vector3 direction;

    private Animator animator;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Idle State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
    }

    void EnemyState.Update()
    {
        animator.SetBool("isIdle", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        // 플레이어와 마주칠 경우
        /*
        // 실행할것 구현
        if (enemy.AttackRange <= distance && distance <= enemy.IdleRange)
        {
            // 다른상태로 이동
            enemy.SetState(new MoveState());
        }
        */
    }

    void EnemyState.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}
