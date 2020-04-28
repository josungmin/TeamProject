using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    Animator animator;

    public float speed = 0.05f;

    private bool canMoving = true;

    float horizontalMove;
    float verticalMove;

    Rigidbody rigidbody;
    Vector3 vector3;

    public int walkCount = 20;
    private int currWalkCount = 0;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            vector3.Set(Input.GetAxisRaw("Horizontal"), transform.position.y, Input.GetAxisRaw("Vertical"));

            while (currWalkCount < walkCount)
            {
                transform.Translate(vector3.x * speed, 0, vector3.z * speed);

                currWalkCount++;
                yield return new WaitForSeconds(0.02f);
            }
            currWalkCount = 0;
        }

        canMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (canMoving)
        {
            canMoving = false;
            StartCoroutine(MoveCoroutine());
        }
    }

    void AnimatonUpdate()
    {
        if (canMoving)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }
}
