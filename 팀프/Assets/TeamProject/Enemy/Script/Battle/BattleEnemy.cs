using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    private BattleEnemyState currentState;
    public GameManager2 gameManager;
    public Player player;
    public int enemy_hp = 30;

    AudioSource aud;
    public AudioSource audioSource; //출력 관련 

    public AudioClip deadSound;  //구르기
    public AudioClip damagedSound;  //걷기
    public AudioClip AttackSound; // 펄스건 기본

    void Awake()
    {
        aud = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();

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

    // 효과음 재생 메소드    // 기본 : 1회재생(반복X)
    public void PlayDamagedSound()
    {
        if (!aud.isPlaying)
            aud.PlayOneShot(damagedSound);
    }

    // 효과음 재생 메소드    // 기본 : 1회재생(반복X)
    public void PlayDeadSound()
    {
        if (!aud.isPlaying)
            aud.PlayOneShot(deadSound);
    }

    // 효과음 재생 메소드    // 기본 : 1회재생(반복X)
    public void PlayAttackSound()
    {
        if (!aud.isPlaying)
            aud.PlayOneShot(AttackSound);
    }
}