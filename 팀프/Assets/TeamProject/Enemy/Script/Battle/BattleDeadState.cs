using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleDeadState : BattleEnemyState
{
    private BattleEnemy enemy;

    private Animator animator;

    public float Current_Time = 0;

    void BattleEnemyState.OnEnter(BattleEnemy enemy)
    {
        Debug.Log("Dead State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
    }

    void BattleEnemyState.Update()
    {
        // 몬스터 죽는소리 여기에 적어주세요.
        //animator.SetBool("isDead", true);

        if (3.0f < Current_Time)
        {
            SceneManager.LoadScene("MainSceneF");
            //enemy.SetState(new BattleIdleState());
            Current_Time = 0;
        }
        Current_Time += Time.deltaTime;
    }

    void BattleEnemyState.OnExit()
    {
        //animator.SetBool("isDead", false);
    }
}
