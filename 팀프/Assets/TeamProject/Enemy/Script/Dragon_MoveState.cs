using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon_MoveState : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    NavMeshAgent nav;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Move State");
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();

        nav = dragon.GetComponent<NavMeshAgent>();
        nav.isStopped = false;

        enemyinfo = dragon.GetComponent<EnemyInfo>();
    }

    void DragonState.Update()
    {
        animator.SetBool("isWalk", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - dragon.transform.position).normalized;

        float distance = Vector3.Distance(target.position, dragon.transform.position);

        //타겟을 향해 이동
        nav.SetDestination(target.transform.position);

        if (enemyinfo.c_HP > enemyinfo.p_HP)
        {
            dragon.SetState(new Dragon_DamagedState());
        }

        // 실행할것 구현
        if (distance >= dragon.IdleRange)
        {
            // 다른상태로 이동
            dragon.SetState(new Dragon_IdleState());
        }
        //공격범위안에 들어왔을 때
        else if (dragon.AttackRange >= distance)
        {
            dragon.SetState(new Dragon_AttackState());
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isWalk", false);
    }
}
