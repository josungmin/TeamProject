using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleIdleState : BattleEnemyState
{
    private BattleEnemy enemy;
    private Animator animator;
    private BattleEnemyInfo enemy_info;

    void BattleEnemyState.OnEnter(BattleEnemy enemy)
    {
        Debug.Log("Idle State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        enemy_info = enemy.GetComponent<BattleEnemyInfo>();
    }

    void BattleEnemyState.Update()
    {
        animator.SetBool("isIdle", true);

        // 플레이어의 움직임이 있을 경우
        // 이동상태로 전이
        if (enemy_info.Hp != enemy_info.pre_Hp)
        {
            enemy.SetState(new BattleDamagedState());
        }

        // 랜덤으로 스킬 쓰는 상태 3개
        if(enemy.gameManager.current_Turn == GameManager2.Turn.ENEMY_TURN && enemy_info.Hp == enemy_info.pre_Hp)
        {
            Debug.Log("공격 시작");
            if (true)
            {
                enemy.SetState(new BattleAttackState());
            }
            /*
            if (true)
            {
                //enemy.SetState(new MoveState());
            }

            if (true)
            {
                //enemy.SetState(new MoveState());
            }
            */
        }
    }

    void BattleEnemyState.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}
