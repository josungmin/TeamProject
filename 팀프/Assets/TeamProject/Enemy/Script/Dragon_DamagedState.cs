using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_DamagedState : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Damaged State");
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();
        enemyinfo = dragon.GetComponent<EnemyInfo>();
        
        enemyinfo.p_HP = enemyinfo.c_HP;
        
    }

    void DragonState.Update()
    {
        animator.SetBool("isDamaged", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - dragon.transform.position).normalized;

        float distance = Vector3.Distance(target.position, dragon.transform.position);

        if (enemyinfo.p_HP <= 0)
        {
            dragon.SetState(new Dragon_DeadState());
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Damaged 0") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            // 실행할것 구현
            if (distance >= dragon.IdleRange)
            {
                dragon.SetState(new Dragon_IdleState());
            }
            // 실행할것 구현
            if (dragon.AttackRange <= distance && distance <= dragon.IdleRange)
            {
                dragon.SetState(new Dragon_MoveState());
            }
            else if (dragon.AttackRange >= distance)
            {
                dragon.SetState(new Dragon_AttackState());
            }
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isDamaged", false);
    }
}
