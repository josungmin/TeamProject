using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    private BattleEnemyState currentState;
    public GameManager2 gameManager;
    public Player player;
    public int enemy_hp = 30;

    void Awake()
    {
        SetState(new BattleIdleState());
    }

    void Update()
    {
        currentState.Update();
    }

    public void SetState(BattleEnemyState nextState)
    {
        // 다음 state로 이동구현
        if (currentState != null)
        {
            // 기존의 상태가 존재했다면 OnExit()호출
            currentState.OnExit();
        }

        // 다음state 시작
        currentState = nextState;
        currentState.OnEnter(this);
    }
}