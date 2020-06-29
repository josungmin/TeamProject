using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    Animator animator;

    public float speed = 0.05f;

    private bool canMoving = true;

    public float horizontalMove;
    public float verticalMove;

    //Rigidbody rigidbody;
    Vector3 vector3;

    public int walkCount = 20;
    private int currWalkCount = 0;

    public int Player_Hp;
    public int Pre_Player_Hp;
    public Slider Hp_bar;

    [SerializeField] GameObject You_Lose_;

    AudioSource aud;
    public AudioSource audioSource; //출력 관련 
    public AudioClip walk; 

    void Awake()
    {
        //rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        aud = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 위치 불러오기
        this.transform.position = new Vector3(PlayerPrefs.GetFloat("playerXpos", 44.0f), PlayerPrefs.GetFloat("playerYpos", 1.0f), PlayerPrefs.GetFloat("playerZpos", 28.0f));

        // HP 불러오기
        if(!PlayerPrefs.HasKey("PlayerHP"))
        {
            PlayerPrefs.SetInt("PlayerHP", 100);
            PlayerPrefs.Save();
        }
           
        Player_Hp = PlayerPrefs.GetInt("PlayerHP", 100);
        Pre_Player_Hp = Player_Hp;

        Hp_bar.value = Player_Hp;
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            vector3.Set(Input.GetAxisRaw("Horizontal"), transform.position.y, Input.GetAxisRaw("Vertical"));

            while (currWalkCount < walkCount)
            {
                transform.Translate(vector3.x * speed, 0, vector3.z * speed);

                if (!aud.isPlaying)
                    aud.PlayOneShot(walk);

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
        if(this.transform.position.y < -3.0f)
        {
            this.transform.position = new Vector3(44.0f, 1.0f, 28.0f);

            Player_Hp -= 5;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        AnimatonUpdate();
        HpUpdate();
        PositionUpdate();

        /*
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
        }
        */
    }

    void FixedUpdate()
    {
        if (canMoving)
        {
            canMoving = false;
            StartCoroutine(MoveCoroutine());
        }
    }

    void PositionUpdate()
    {
        if(canMoving)
        {
            PlayerPrefs.SetFloat("playerXpos", this.transform.position.x);
            PlayerPrefs.SetFloat("playerYpos", this.transform.position.y);
            PlayerPrefs.SetFloat("playerZpos", this.transform.position.z);

            PlayerPrefs.Save();
        }
    }

    void HpUpdate()
    {
        if(Player_Hp <= 0)
        {
            You_Lose_.SetActive(true);
        }

        if(Player_Hp < Pre_Player_Hp)
        {
            PlayerPrefs.SetInt("PlayerHP", Player_Hp);
            PlayerPrefs.Save();

            Hp_bar.value = Player_Hp;
            Pre_Player_Hp = Player_Hp;
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
