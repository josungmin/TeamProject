using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyState
{
    private Enemy enemy;
    private Animator animator;
    private Transform tr;

    // 이동
    public bool isWalk;
    public Vector3 MovePoint;
    public int randNum;

    void EnemyState.OnEnter(Enemy enemy)
    {
        Debug.Log("Move State");
        this.enemy = enemy;
        animator = enemy.GetComponent<Animator>();
        tr = enemy.GetComponent<Transform>();
        isWalk = true;

    }

    void EnemyState.Update()
    {
        //animator.SetBool("isWalk", true);

        // 랜덤으로 상하좌우 중 한곳을 한칸 이동
        if(isWalk)
        {
            randNum = Random.RandomRange(0, 4);

            // 이동 방향 지정
            SetPosition(randNum);

            // 이동
            StartMove(randNum);
        }

        // 이동이 끝났다면 Idle 상태로 전이
        if (enemy.transform.position == MovePoint)
        {
            enemy.SetState(new IdleState());
        }
    }

    void EnemyState.OnExit()
    {
        initPosition();
        //animator.SetBool("isWalk", false);
    }

    void SetPosition(int randNum)
    {
        if (randNum == 0)
        {
            MovePoint.Set(enemy.transform.position.x + 1, enemy.transform.position.y, enemy.transform.position.z);
        }
        else if (randNum == 1)
        {
            MovePoint.Set(enemy.transform.position.x - 1, enemy.transform.position.y, enemy.transform.position.z);
        }
        else if (randNum == 2)
        {
            MovePoint.Set(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 1);
        }
        else if (randNum == 3)
        {
            MovePoint.Set(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z - 1);
        }
    }

    void StartMove(int randNum)
    {
        // 이동
        if (randNum == 0 && enemy.right_col == false)
        {
            iTween.MoveBy(enemy.gameObject, iTween.Hash("x", 1, "speed", 2.2f, "easeType", iTween.EaseType.linear));
            isWalk = false;
        }
        else if (randNum == 1 && enemy.left_col == false)
        {
            iTween.MoveBy(enemy.gameObject, iTween.Hash("x", -1, "speed", 2.2f, "easeType", iTween.EaseType.linear));
            isWalk = false;
        }
        else if (randNum == 2 && enemy.front_col == false)
        {
            iTween.MoveBy(enemy.gameObject, iTween.Hash("z", 1, "speed", 2.2f, "easeType", iTween.EaseType.linear));
            isWalk = false;
        }
        else if (randNum == 3 && enemy.back_col == false)
        {
            iTween.MoveBy(enemy.gameObject, iTween.Hash("z", -1, "speed", 2.2f, "easeType", iTween.EaseType.linear));
            isWalk = false;
        }
    }

    void initPosition()
    {
        enemy.right_col = false;
        enemy.left_col = false;
        enemy.front_col = false;
        enemy.back_col = false;
    }
}
