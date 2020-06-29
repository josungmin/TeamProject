using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayNextScene2 : MonoBehaviour
{
    public Image img;

    float fades = 0.0f;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (fades > 0.0f && time >= 0.1f)
        {
            fades += 0.05f;
            img.color = new Color(0, 0, 0, fades);
            time = 0;
        }

        else if (fades >= 1.0f)
        {
            time = 0;
        }
    }
}
