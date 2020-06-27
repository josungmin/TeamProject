using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveEvent : MonoBehaviour
{
    public GameObject mainCharacter;

    public float speed = 0.05f;

    public int walkCount = 20;
    private int currWalkCount = 0;

    private bool canMoving = true;

    Vector3 vector3;

    IEnumerator MoveCoroutine()
    {
        while (currWalkCount < walkCount)
        {
            mainCharacter.transform.Translate(vector3.x * speed, 0, vector3.z * speed);

            currWalkCount++;
            yield return new WaitForSeconds(0.02f);
        }
        currWalkCount = 0;

        canMoving = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void walkFoward()
    {
        if (canMoving)
        {
            canMoving = false;
            vector3 = new Vector3(0, 0, 1);

            StartCoroutine(MoveCoroutine());
        }
    }

    public void walkBackward()
    {
        if (canMoving)
        {
            canMoving = false;
            vector3 = new Vector3(0, 0, -1);

            StartCoroutine(MoveCoroutine());
        }
    }

    public void walkLeft()
    {
        if (canMoving)
        {
            canMoving = false;
            vector3 = new Vector3(-1, 0, 0);

            StartCoroutine(MoveCoroutine());
        }
    }

    public void walkRight()
    {
        if (canMoving)
        {
            canMoving = false;
            vector3 = new Vector3(1, 0, 0);

            StartCoroutine(MoveCoroutine());
        }
    }
}
