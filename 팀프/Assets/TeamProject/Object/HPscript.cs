using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPscript : MonoBehaviour
{
    public float value;
    public Slider healthBar;


    // Text컴포넌트 담아두기;
    void Start()
    {
        
    }

    // score 갱신;
    void Update()
    {

        healthBar.value = value;
    }
}
