using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    private Enemy enemy;

    public MainCharacter player;
    public Vector3 direction;

    private Animator animator;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Idle State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();
    }

    void EnemyState.Update()
    {
        animator.SetBool("isIdle", true);

        // 플레이어의 움직임이 있을 경우     
        if (player.horizontalMove != 0 || player.verticalMove != 0)
        {
            // 이동 상태로 전이
            enemy.SetState(new MoveState());
        }
        
    }

    void EnemyState.OnExit()
    {
        animator.SetBool("isIdle", false);
    }
}
