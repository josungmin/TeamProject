using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DragonState
{
    // 인터페이스로 구현함으로써 player클래스에서 이 인터페이스로 호출합니다.
    void OnEnter(Dragon dragon);
    void Update();
    void OnExit();
}

