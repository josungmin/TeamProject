using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject go_UI;

    public void ShowClearUI()
    {
        go_UI.SetActive(true);
    }

}
