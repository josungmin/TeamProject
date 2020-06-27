using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BattleEnemyState
{
    // 인터페이스로 구현함으로써 player클래스에서 이 인터페이스로 호출합니다.
    void OnEnter(BattleEnemy enemy);
    void Update();
    void OnExit();
}

