using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject DragonPrefab;

    private DragonState currentState;
    private Vector3 Direction;

    public float IdleRange = 15.0f;
    public float AttackRange = 7.0f;

    void Awake()
    {
        SetState(new Dragon_IdleState());
    }

    void Update()
    {
        currentState.Update();
    }

    public void SetState(DragonState nextState)
    {
        // 다음 state로 이동구현
        if (currentState != null)
        {
            // 기존의 상태가 존재했다면 OnExit()호출
            currentState.OnExit();
        }

        // 다음state 시작
        currentState = nextState;
        currentState.OnEnter(this);
    }

    public void destroyToDead()
    {
        Destroy(DragonPrefab);
    }
}

#if false
    public Transform target;
    public Vector3 direction;
    public float velocity;

    Animator animator;

    public enum State
    {
        IDLE,
        MOVE,
        ATTACK,
        DAMAGED,
        DEAD,
    };
    private State currentState_ = State.IDLE;

    public void SetState(State newState)
    {
        //공격중 다시 공격 못하도록
        if (newState == currentState_)
            return;

        //현재 상태가 있다면 종료

        currentState_ = newState;
        
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    public void MoveToPlayer()
    {
        target = GameObject.Find("Player").transform;
        direction = (target.position - transform.position).normalized;

        //Enemy 속도 지정
        velocity = 0.03f;

        float distance = Vector3.Distance(target.position, transform.position);

        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (1.3f <= distance && distance <= 10.0f)
        {
            animator.SetBool("isWalk", true);
            SetState(State.MOVE);
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y + (direction.y * velocity),
                                                     transform.position.z + (direction.z * velocity));

            //타겟을 바라보게
            Vector3 dirToTarget = this.target.transform.position - this.transform.position;
            Vector3 look = Vector3.Slerp(this.transform.forward, dirToTarget.normalized, Time.deltaTime * 3.0f);

            this.transform.rotation = Quaternion.LookRotation(look, Vector3.up);

        }

        // 일정거리 밖에 있을 시, 속도 초기화 
        else if(distance >= 10.0f)
        {
            animator.SetBool("isWalk", false);
            velocity = 0.0f;
        }
    }
}

public class Enemy : MonoBehaviour
{
    public EnemyInfo enemyinfo;
    public float pre_hp;

    public Transform target;
    public Vector3 direction;
    public float velocity = 0.03f;

    public Animator animator;

    public enum State
    {
        IDLE,
        MOVE,
        ATTACK,
        DAMAGED,
        DEAD,
    };
    private State currentState_ = State.IDLE;

    public void SetState(State newState)
    {
        //공격중 다시 공격 못하도록
        if (newState == currentState_)
            return;

        //현재 상태가 있다면 종료
        
        currentState_ = newState;

        switch (newState)
        {
            case State.IDLE:
                {
                    Debug.Log("State.IDLE");
                    StartCoroutine(Idle());
                }
                break;
            case State.MOVE:
                {
                    Debug.Log("State.MOVE");
                    StartCoroutine(MoveToPlayer());
                }
                break;
            case State.ATTACK:
                {
                    Debug.Log("State.Attack");
                    StartCoroutine(Attack());
                }
                break;
            case State.DAMAGED:
                {
                    Debug.Log("State.DAMAGED");
                    StartCoroutine(Damaged());
                }
                break;
            case State.DEAD:
                {
                    Debug.Log("State.DEAD");
                    StartCoroutine(Dead());
                }
                break;
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pre_hp = enemyinfo.p_HP;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }

    void ChangeState()
    {
        target = GameObject.Find("Player").transform;
        direction = (target.position - transform.position).normalized;

        float distance = Vector3.Distance(target.position, transform.position);

        //적의 체력이 0 이하일 때
        if (enemyinfo.p_HP <= 0)
        {
            SetState(State.DEAD);
        }

        if(pre_hp != enemyinfo.p_HP)
        {
            SetState(State.DAMAGED);
        }

        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (1.3f <= distance && distance <= 10.0f)
        {
            SetState(State.MOVE);
        }

        //공격범위안에 들어왔을 때
        if (1.3f >= distance)
        {
            SetState(State.ATTACK);
        }

        // 일정거리 밖에 있을 시, 속도 초기화 
        if (10.0f <= distance)
        {
            SetState(State.DEAD);
        }
    }

    public IEnumerator Idle()
    {
        animator.SetBool("isIdle", true);
        yield return new WaitForSeconds(0.1f);
        velocity = 0.0f;
    }

    public IEnumerator MoveToPlayer()
    {
        //animator.SetBool("isWalk", true);
        yield return new WaitForSeconds(0.1f);
        target = GameObject.Find("Player").transform;
        direction = (target.position - transform.position).normalized;

        //Enemy 속도 지정
        float distance = Vector3.Distance(target.position, transform.position);

        this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y + (direction.y * velocity),
                                                     transform.position.z + (direction.z * velocity));

        /*
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (1.3f <= distance && distance <= 10.0f)
        {
            
        }
        //공격범위안에 들어왔을 때
        if(1.3f >= distance)
        {

        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        if(10.0f <= distance)
        {
            velocity = 0.0f;
        }
        */
    }

    public IEnumerator Attack()
    {
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isAttack", false);

        StopCoroutine(Attack());
    }

    public IEnumerator Damaged()
    {
        animator.SetBool("isDamaged", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("isDamaged", false);
    }

    public IEnumerator Dead()
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

}
#endif