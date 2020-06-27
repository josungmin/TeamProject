using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1 : MonoBehaviour
{
    public bool Cheack;
    public float Current_Time = 0;

    //private BattleEnemyInfo enemy_info;

    // Start is called before the first frame update
    void Start()
    {
        //enemy_info = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BattleEnemyInfo>();
        Cheack = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (1.0f < Current_Time)
        {
            Cheack = true;
            Current_Time = 0;
        }
        Current_Time += Time.deltaTime;
        */
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Enemy" && Cheack == true)
        {
            Cheack = false;
            other.GetComponent<BattleEnemyInfo>().Hp -= Random.Range(12, 18);
        }
    }
}
