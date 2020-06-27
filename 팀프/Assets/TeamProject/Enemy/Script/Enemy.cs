using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyState currentState;
    private Vector3 Direction;
    public bool isBattle;

    public bool front_col;
    public bool back_col;
    public bool right_col;
    public bool left_col;

    void Awake()
    {
        isBattle = false;

        SetState(new IdleState());
    }

    void Start()
    {
        // 위치 저장
        if (this.gameObject.tag == "Enemy1")
        {
            if (PlayerPrefs.GetInt("Enemy1_Alive", 0) == 1)
            {
                this.transform.position = new Vector3(
                    PlayerPrefs.GetFloat("enemy1_xPos", this.transform.position.x),
                PlayerPrefs.GetFloat("enemy1_yPos", this.transform.position.y),
                PlayerPrefs.GetFloat("enemy1_zPos", this.transform.position.z));
            }
            else
                Destroy(this.gameObject);

        }

        if (this.gameObject.tag == "Enemy2")
        {
            if (PlayerPrefs.GetInt("Enemy2_Alive", 0) == 1)
            {
                this.transform.position = new Vector3(
                    PlayerPrefs.GetFloat("enemy2_xPos", this.transform.position.x),
                PlayerPrefs.GetFloat("enemy2_yPos", this.transform.position.y),
                PlayerPrefs.GetFloat("enemy2_zPos", this.transform.position.z));
            }
            else
                Destroy(this.gameObject);
        }
        if (this.gameObject.tag == "Enemy3")
        {
            if (PlayerPrefs.GetInt("Enemy3_Alive", 0) == 1)
            {
                this.transform.position = new Vector3(
                    PlayerPrefs.GetFloat("enemy3_xPos", this.transform.position.x),
                PlayerPrefs.GetFloat("enemy3_yPos", this.transform.position.y),
                PlayerPrefs.GetFloat("enemy3_zPos", this.transform.position.z));
            }
            else
                Destroy(this.gameObject);
        }
        if (this.gameObject.tag == "Enemy4")
        {
            if (PlayerPrefs.GetInt("Enemy4_Alive", 0) == 1)
            {
                this.transform.position = new Vector3(
                    PlayerPrefs.GetFloat("enemy4_xPos", this.transform.position.x),
                PlayerPrefs.GetFloat("enemy4_yPos", this.transform.position.y),
                PlayerPrefs.GetFloat("enemy4_zPos", this.transform.position.z));
            }
            else
                Destroy(this.gameObject);
        }
        if (this.gameObject.tag == "Enemy5")
        {
            if (PlayerPrefs.GetInt("Enemy5_Alive", 0) == 1)
            {
                this.transform.position = new Vector3(
                    PlayerPrefs.GetFloat("enemy5_xPos", this.transform.position.x),
                PlayerPrefs.GetFloat("enemy5_yPos", this.transform.position.y),
                PlayerPrefs.GetFloat("enemy5_zPos", this.transform.position.z));
            }
            else
                Destroy(this.gameObject);
        }
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
            // 위치 저장
            if (this.gameObject.tag == "Enemy1")
            {
                PlayerPrefs.SetInt("Enemy1_Alive", 0);

                PlayerPrefs.Save();
            }
            if (this.gameObject.tag == "Enemy2")
            {
                PlayerPrefs.SetInt("Enemy2_Alive", 0);

                PlayerPrefs.Save();
            }
            if (this.gameObject.tag == "Enemy3")
            {
                PlayerPrefs.SetInt("Enemy3_Alive", 0);

                PlayerPrefs.Save();
            }
            if (this.gameObject.tag == "Enemy4")
            {
                PlayerPrefs.SetInt("Enemy4_Alive", 0);

                PlayerPrefs.Save();
            }
            if (this.gameObject.tag == "Enemy5")
            {
                PlayerPrefs.SetInt("Enemy5_Alive", 0);

                PlayerPrefs.Save();
            }

            isBattle = true;
        }
        /*
        if (col.gameObject.CompareTag("Player"))
        {
            isBattle = true;
        }
        */
    }
}