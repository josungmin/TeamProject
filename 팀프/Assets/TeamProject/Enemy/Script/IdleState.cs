using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    private Enemy enemy;

    public MainCharacter player;

    private Animator animator;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Idle State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();

        // 위치 저장
        if(enemy.gameObject.tag == "Enemy1")
        {
            PlayerPrefs.SetFloat("enemy1_xPos", enemy.transform.position.x);
            PlayerPrefs.SetFloat("enemy1_yPos", enemy.transform.position.y);
            PlayerPrefs.SetFloat("enemy1_zPos", enemy.transform.position.z);

            PlayerPrefs.Save();
        }
        if (enemy.gameObject.tag == "Enemy2")
        {
            PlayerPrefs.SetFloat("enemy2_xPos", enemy.transform.position.x);
            PlayerPrefs.SetFloat("enemy2_yPos", enemy.transform.position.y);
            PlayerPrefs.SetFloat("enemy2_zPos", enemy.transform.position.z);

            PlayerPrefs.Save();
        }
        if (enemy.gameObject.tag == "Enemy3")
        {
            PlayerPrefs.SetFloat("enemy3_xPos", enemy.transform.position.x);
            PlayerPrefs.SetFloat("enemy3_yPos", enemy.transform.position.y);
            PlayerPrefs.SetFloat("enemy3_zPos", enemy.transform.position.z);

            PlayerPrefs.Save();
        }
        if (enemy.gameObject.tag == "Enemy4")
        {
            PlayerPrefs.SetFloat("enemy4_xPos", enemy.transform.position.x);
            PlayerPrefs.SetFloat("enemy4_yPos", enemy.transform.position.y);
            PlayerPrefs.SetFloat("enemy4_zPos", enemy.transform.position.z);

            PlayerPrefs.Save();
        }
        if (enemy.gameObject.tag == "Enemy5")
        {
            PlayerPrefs.SetFloat("enemy5_xPos", enemy.transform.position.x);
            PlayerPrefs.SetFloat("enemy5_yPos", enemy.transform.position.y);
            PlayerPrefs.SetFloat("enemy5_zPos", enemy.transform.position.z);

            PlayerPrefs.Save();
        }
        //MainGameManager.Instance.is_move = false;
    }

    void EnemyState.Update()
    {
        //animator.SetBool("isIdle", true);

        if(enemy.isBattle == true)
        {
            enemy.SetState(new AttackState());
        }

        // 플레이어의 움직임이 있을 경우     
        if (player.horizontalMove != 0 || player.verticalMove != 0)
        {
            // 이동 상태로 전이
            enemy.SetState(new MoveState());
        }
    }

    void EnemyState.OnExit()
    {
        //animator.SetBool("isIdle", false);
    }
}
