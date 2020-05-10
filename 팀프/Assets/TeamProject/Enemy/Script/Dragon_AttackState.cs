using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon_AttackState : DragonState
{
    private Dragon dragon;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    public float _Damage = 10.0f;

    NavMeshAgent nav;

    void DragonState.OnEnter(Dragon dragon)
    {
        Debug.Log("Attack State");
        this.dragon = dragon;
        animator = dragon.GetComponent<Animator>();
        enemyinfo = dragon.GetComponent<EnemyInfo>();

        nav = dragon.GetComponent<NavMeshAgent>();
        nav.isStopped = true;
    }

    void DragonState.Update()
    {
        animator.SetBool("isAttack", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - dragon.transform.position).normalized;

        float distance = Vector3.Distance(target.position, dragon.transform.position);

        /*
        if (dragon.GetComponent<GiveDamage>().enterPlayer == true)
        {
            Debug.Log("GiveDamage ok?");
            if (dragon.GetComponent<GiveDamage>().DamageCount == 0)
            {
                dragon.GetComponent<GiveDamage>().DamageCount++;
                target.GetComponent<PlayerInfo>().UIUpdate("Damage", "HP", _Damage);
            }
        }
        */
        if (enemyinfo.c_HP < enemyinfo.p_HP)
        {
            dragon.SetState(new Dragon_DamagedState());
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack 0") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Vector3 dirToTarget = this.target.transform.position - dragon.transform.position;
            Vector3 look = Vector3.Slerp(dragon.transform.forward, dirToTarget.normalized, Time.deltaTime * 3.0f);

            dragon.transform.rotation = Quaternion.LookRotation(look, Vector3.up);

            // 실행할것 구현
            if (dragon.AttackRange <= distance && distance <= dragon.IdleRange)
            {
                // 다른상태로 이동
                dragon.SetState(new Dragon_MoveState());
            }
        }
    }

    void DragonState.OnExit()
    {
        animator.SetBool("isAttack", false);
    }
}
