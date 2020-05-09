using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyState currentState;
    private Vector3 Direction;
    public bool isBattle;

    void Awake()
    {
        isBattle = false;

        SetState(new IdleState());
    }

    void Update()
    {
        currentState.Update();
    }

    public void SetState(EnemyState nextState)
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

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isBattle = true;
        }
        
        if (col.gameObject.CompareTag("Player"))
        {
            isBattle = true;
        }
        
    }
}