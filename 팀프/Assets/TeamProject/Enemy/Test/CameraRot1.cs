using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRot1 : MonoBehaviour
{
    public float speed;
    float y;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        y += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
