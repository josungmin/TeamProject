using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : EnemyState
{
    private Enemy enemy;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    NavMeshAgent nav;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Move State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();

        nav = enemy.GetComponent<NavMeshAgent>();
        nav.isStopped = false;

        enemyinfo = enemy.GetComponent<EnemyInfo>();
    }

    void EnemyState.Update()
    {
        animator.SetBool("isWalk", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

        //타겟을 향해 이동
        nav.SetDestination(target.transform.position);

        if (enemyinfo.c_HP > enemyinfo.p_HP)
        {
            enemy.SetState(new DamagedState());
        }
        /*
        // 실행할것 구현
        if (distance >= enemy.IdleRange)
        {
            // 다른상태로 이동
            enemy.SetState(new IdleState());
        }
        //공격범위안에 들어왔을 때
        else if (enemy.AttackRange >= distance)
        {
            enemy.SetState(new AttackState());
        }
        */
    }

    void EnemyState.OnExit()
    {
        animator.SetBool("isWalk", false);
    }
}
