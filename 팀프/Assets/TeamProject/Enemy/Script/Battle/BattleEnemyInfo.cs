using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyInfo : MonoBehaviour
{
    public int Hp;
    public int pre_Hp;

    public Slider Hp_bar;

    // Start is called before the first frame update
    void Start()
    {
        Hp = 30;
        pre_Hp = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        Hp_bar.value = Hp;
    }
}
