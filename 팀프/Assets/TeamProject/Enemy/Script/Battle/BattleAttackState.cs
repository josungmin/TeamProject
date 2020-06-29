using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleAttackState : BattleEnemyState
{
    private BattleEnemy enemy;
    private Animator animator;

    public float Current_Time = 0;

    void BattleEnemyState.OnEnter(BattleEnemy enemy)
    {
        Debug.Log("Attack State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();

    }

    void BattleEnemyState.Update()
    {
        animator.SetBool("isAttack", true);

        enemy.PlayAttackSound();
        // 몬스터 공격 소리 여기다가 적어주세요
        //////////
        //////////

        // 플레이어 공격애니메이션 기다림

        //공격 끝나면 idle 상태로 전이
        if (2.0f < Current_Time)
        {
            enemy.player.Cur_player_hp -= Random.Range(5, 10);

            enemy.SetState(new BattleIdleState());
            Current_Time = 0;
        }
        Current_Time += Time.deltaTime;

    }

    void BattleEnemyState.OnExit()
    {
        enemy.gameManager.current_Turn = GameManager2.Turn.PLAYER_TURN;
        animator.SetBool("isAttack", false);
    }
}
