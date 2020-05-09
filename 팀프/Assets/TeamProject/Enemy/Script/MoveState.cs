using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyState
{
    private Enemy enemy;
    private Animator animator;

    public bool isWalk;
    public Vector3 MovePoint;
    public int randNum;
    public float speed = 0.05f;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Move State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        isWalk = true;

        // 이동 방향 지정
        randNum = Random.RandomRange(0, 4);

        if(randNum == 0)
        {
            MovePoint.Set(enemy.transform.position.x + 1, enemy.transform.position.y, enemy.transform.position.z);
        }
        else if(randNum == 1)
        {
            MovePoint.Set(enemy.transform.position.x - 1, enemy.transform.position.y, enemy.transform.position.z);
        }
        else if(randNum == 2)
        {
            MovePoint.Set(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 1);
        }
        else if(randNum == 3)
        {
            MovePoint.Set(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z - 1);
        }
    }

    void EnemyState.Update()
    {
        animator.SetBool("isWalk", true);

        // 랜덤으로 상하좌우 중 한곳을 한칸 이동
        if(isWalk)
        {
            isWalk = false;
            if(randNum == 0)
            {
                iTween.MoveBy(enemy.gameObject, iTween.Hash("x", 1,"speed", 2.2f, "easeType", iTween.EaseType.linear));
            }
            else if (randNum == 1)
            {
                iTween.MoveBy(enemy.gameObject, iTween.Hash("x", -1, "speed", 2.2f, "easeType", iTween.EaseType.linear));
            }
            else if (randNum == 2)
            {
                iTween.MoveBy(enemy.gameObject, iTween.Hash("z", 1, "speed", 2.2f, "easeType", iTween.EaseType.linear));
            }
            else if (randNum == 3)
            {
                iTween.MoveBy(enemy.gameObject, iTween.Hash("z", -1, "speed", 2.2f, "easeType", iTween.EaseType.linear));
            }
        }

        // 이동이 끝났다면 Idle 상태로 전이
        if (enemy.transform.position == MovePoint)
        {
            enemy.SetState(new IdleState());
        }
        /*
        // 실행할것 구현
        if (distance >= enemy.IdleRange)
        {
            // 다른상태로 이동
            enemy.SetState(new IdleState());
        }
        //공격범위안에 들어왔을 때
        else if (enemy.AttackRange >= distance)
        {
            enemy.SetState(new AttackState());
        }
        */
    }

    void EnemyState.OnExit()
    {
        animator.SetBool("isWalk", false);
    }
}
