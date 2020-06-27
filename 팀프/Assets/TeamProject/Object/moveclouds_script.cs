using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveclouds_script : MonoBehaviour
{
    float x_speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        x_speed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x_speed, 0, 0);
        if (transform.position.x > 700)
        {
            Destroy(gameObject, 0);
        }
    }
}
