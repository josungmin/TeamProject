using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public enum Turn
    {
        PLAYER_TURN,
        ENEMY_TURN
    };
    public Turn current_Turn = Turn.PLAYER_TURN;
    public Turn pre_Turn;

    public RawImage player_turn;
    public RawImage enemy_turn;

    // Start is called before the first frame update
    void Start()
    {
        pre_Turn = current_Turn;
        player_turn.gameObject.SetActive(true);
        enemy_turn.gameObject.SetActive(false);

        Invoke("SetFalsePlayer", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {     
        if(pre_Turn != current_Turn)
        {
            SetImg();
            pre_Turn = current_Turn;


        }       
    }

    void SetImg()
    {
        if (current_Turn == Turn.PLAYER_TURN)
        {
            player_turn.gameObject.SetActive(true);

            Invoke("SetFalse", 1.0f);
        }

        if (current_Turn == Turn.ENEMY_TURN)
        {
            enemy_turn.gameObject.SetActive(true);

            Invoke("SetFalse", 1.0f);
        }
    }

    void SetFalse()
    {
        if (current_Turn == Turn.PLAYER_TURN)
        {
            player_turn.gameObject.SetActive(false);
        }

        if (current_Turn == Turn.ENEMY_TURN)
        {
            enemy_turn.gameObject.SetActive(false);
        }
    }

    void SetFalsePlayer()
    {
        player_turn.gameObject.SetActive(false);
    }
}
