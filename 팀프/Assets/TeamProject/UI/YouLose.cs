using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouLose : MonoBehaviour
{
    [SerializeField] GameObject You_Lose_;

    public void ShowClearUI()
    {
        You_Lose_.SetActive(true);
    }

}
