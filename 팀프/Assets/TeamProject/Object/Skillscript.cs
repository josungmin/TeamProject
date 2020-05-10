using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillscript : MonoBehaviour
{
    public float value;
    public Slider skillBar;


    // Text컴포넌트 담아두기;
    void Start()
    {

    }

    // score 갱신;
    void Update()
    {

        skillBar.value = value;
    }
}
