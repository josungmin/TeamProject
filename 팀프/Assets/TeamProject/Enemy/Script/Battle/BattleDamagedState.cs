using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDamagedState : BattleEnemyState
{
    private BattleEnemy enemy;

    private Animator animator;
    private BattleEnemyInfo enemy_info;

    public float Current_Time = 0;

    void BattleEnemyState.OnEnter(BattleEnemy enemy)
    {
        Debug.Log("Damaged State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        enemy_info = enemy.GetComponent<BattleEnemyInfo>();

        enemy_info.pre_Hp = enemy_info.Hp;
        
    }

    void BattleEnemyState.Update()
    {
        animator.SetBool("isDamaged", true);
        enemy.PlayDamagedSound();
        // 몬스터 피격 소리 여기에다가 적어주세요.
        
        // HP가 0 이하가 된다면 dead 상태로 전이
        if (enemy_info.pre_Hp <= 0)
        {
            enemy.SetState(new BattleDeadState());
        }

        // 피격 애니메이션 지속 시간
        //   ▼
        if (2.0f < Current_Time)
        {
            enemy.SetState(new BattleIdleState());
            Current_Time = 0;
        }
        Current_Time += Time.deltaTime;

        /*
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

    void BattleEnemyState.OnExit()
    {
        animator.SetBool("isDamaged", false);
    }
}
