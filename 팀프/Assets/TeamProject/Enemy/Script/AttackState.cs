using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : EnemyState
{
    private Enemy enemy;

    public Transform target;
    public Vector3 direction;

    private Animator animator;
    private EnemyInfo enemyinfo;

    public float _Damage = 10.0f;

    NavMeshAgent nav;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Attack State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        enemyinfo = enemy.GetComponent<EnemyInfo>();

        nav = enemy.GetComponent<NavMeshAgent>();
        nav.isStopped = true;
    }

    void EnemyState.Update()
    {
        animator.SetBool("isAttack", true);
        target = GameObject.Find("Player").transform;
        direction = (target.position - enemy.transform.position).normalized;

        float distance = Vector3.Distance(target.position, enemy.transform.position);

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

        /*
        if (enemyinfo.c_HP < enemyinfo.p_HP)
        {
            enemy.SetState(new DamagedState());
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack 0") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Vector3 dirToTarget = this.target.transform.position - enemy.transform.position;
            Vector3 look = Vector3.Slerp(enemy.transform.forward, dirToTarget.normalized, Time.deltaTime * 3.0f);

            enemy.transform.rotation = Quaternion.LookRotation(look, Vector3.up);

            // 실행할것 구현
            if (enemy.AttackRange <= distance && distance <= enemy.IdleRange)
            {
                // 다른상태로 이동
                enemy.SetState(new MoveState());
            }
        }
        */
    }

    void EnemyState.OnExit()
    {
        animator.SetBool("isAttack", false);
    }
}
