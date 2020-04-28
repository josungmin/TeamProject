using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;

    public float offsetX = 68.4f;
    public float offsetY = 62.2f;
    public float offsetZ = -68.1f;

    public float followSpeed = 1f;

    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
    }
}
