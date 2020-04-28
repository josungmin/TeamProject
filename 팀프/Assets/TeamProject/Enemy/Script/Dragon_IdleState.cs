using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_IdleState : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Idle State");
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();
    }

    void DragonState.Update()
    {
        animator.SetBool("isIdle", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - dragon.transform.position).normalized;

        float distance = Vector3.Distance(target.position, dragon.transform.position);

        // 실행할것 구현
        if (dragon.AttackRange <= distance && distance <= dragon.IdleRange)
        {
            // 다른상태로 이동
            dragon.SetState(new Dragon_MoveState());
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}
