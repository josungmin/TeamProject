using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDir : MonoBehaviour
{
    public Enemy enemy_sc;

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Map")
        {
            if(this.tag == "enemy_front")
            {
                enemy_sc.front_col = true;
            }

            if (this.tag == "enemy_back")
            {
                enemy_sc.back_col = true;
            }

            if (this.tag == "enemy_right")
            {
                enemy_sc.right_col = true;
            }

            if (this.tag == "enemy_left")
            {
                enemy_sc.left_col = true;
            }
        }
    }
}
