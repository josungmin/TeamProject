using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createclouds_script : MonoBehaviour
{
    public GameObject cloud;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Instantiate(cloud, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.identity);
            timer = 0;
        }
        
    }
}
