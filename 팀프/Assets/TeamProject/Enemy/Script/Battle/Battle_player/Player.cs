using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator animator;

    public bool my_turn = true;

    //애니메이션
    public Coroutine attackRoutine;

    public GameObject[] spellPrefab;
    public GameObject Attack_Pos;
    public int select;

    public GameManager2 gamemanager;

    public int Cur_player_hp;
    public int pre_player_hp;

    public Slider Hp_bar;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        Cur_player_hp = PlayerPrefs.GetInt("PlayerHP", 100);
        pre_player_hp = Cur_player_hp;
    }

    // Start is called before the first frame update
    void Start()
    {


        select = 0;
        my_turn = true;
    }

    // Update is called once per frame
    void Update()
    {
        Hp_Update();

        if (gamemanager.current_Turn == GameManager2.Turn.PLAYER_TURN && my_turn == true)
        {
            if(select == 1)
            {
                my_turn = false;
                select = 0;

                attackRoutine = StartCoroutine(CastSkill_1());
            }
            
            else if(select == 2)
            {
                my_turn = false;
                select = 0;

                attackRoutine = StartCoroutine(CastSkill_2());
            }

            else if(select == 3)
            {
                my_turn = false;
                select = 0;

                attackRoutine = StartCoroutine(CastSkill_3());
            }

            else if(select == 4)
            {
                my_turn = false;
                select = 0;

                attackRoutine = StartCoroutine(CastSkill_4());
            }
        }
    }
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public IEnumerator CastSkill_1()
    {
        animator.SetBool("isCastSpell_1", true);
        yield return new WaitForSeconds(1.5f); //캐스팅 애니메이션 재생 시간

        GameObject spell = spellPrefab[0]; //test
        Skill_1 s = Instantiate(spell, Attack_Pos.transform.position, spell.transform.rotation).GetComponent<Skill_1>();

        yield return new WaitForSeconds(0.8f); //이펙트 애니메이션 재생 시간

        StopSkill_1();
    }

    void StopSkill_1()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            gamemanager.current_Turn = GameManager2.Turn.ENEMY_TURN;
            my_turn = true;
            animator.SetBool("isCastSpell_1", false);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public IEnumerator CastSkill_2()
    {
        animator.SetBool("isCastSpell_2", true);
        yield return new WaitForSeconds(1.2f); //캐스팅 애니메이션 재생 시간

        GameObject spell = spellPrefab[1]; //test
        Skill_1 s = Instantiate(spell, Attack_Pos.transform.position, spell.transform.rotation).GetComponent<Skill_1>();

        yield return new WaitForSeconds(0.8f); //이펙트 애니메이션 재생 시간

        StopSkill_2();
    }

    void StopSkill_2()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            gamemanager.current_Turn = GameManager2.Turn.ENEMY_TURN;
            my_turn = true;
            animator.SetBool("isCastSpell_2", false);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public IEnumerator CastSkill_3()
    {
        animator.SetBool("isCastSpell_3", true);
        yield return new WaitForSeconds(0.2f); //캐스팅 애니메이션 재생 시간

        GameObject spell = spellPrefab[2]; //test
        Skill_1 s = Instantiate(spell, Attack_Pos.transform.position, spell.transform.rotation).GetComponent<Skill_1>();

        yield return new WaitForSeconds(1.0f); //이펙트 애니메이션 재생 시간

        StopSkill_3();
    }

    void StopSkill_3()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            gamemanager.current_Turn = GameManager2.Turn.ENEMY_TURN;
            my_turn = true;
            animator.SetBool("isCastSpell_3", false);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public IEnumerator CastSkill_4()
    {
        animator.SetBool("isCastSpell_4", true);
        yield return new WaitForSeconds(2.1f); //캐스팅 애니메이션 재생 시간

        GameObject spell = spellPrefab[3]; //test
        Skill_1 s = Instantiate(spell, Attack_Pos.transform.position, spell.transform.rotation).GetComponent<Skill_1>();

        yield return new WaitForSeconds(1.0f); //이펙트 애니메이션 재생 시간

        StopSkill_4();
    }

    void StopSkill_4()
    {
        if (attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            gamemanager.current_Turn = GameManager2.Turn.ENEMY_TURN;
            my_turn = true;
            animator.SetBool("isCastSpell_4", false);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 버튼 입력
    public void Select_1()
    {
        if (gamemanager.current_Turn == GameManager2.Turn.PLAYER_TURN)
        {
            Debug.Log("Select 1 Skill ");
            select = 1;
        }
    }

    public void Select_2()
    {
        if (gamemanager.current_Turn == GameManager2.Turn.PLAYER_TURN)
        {
            Debug.Log("Select 2 Skill ");
            select = 2;
        }
    }

    public void Select_3()
    {
        if (gamemanager.current_Turn == GameManager2.Turn.PLAYER_TURN)
        {
            Debug.Log("Select 3 Skill ");
            select = 3;
        }
    }

    public void Select_4()
    {
        if (gamemanager.current_Turn == GameManager2.Turn.PLAYER_TURN)
        {
            Debug.Log("Select 4 Skill ");
            select = 4;
        }
    }

    public void Hp_Update()
    {
        if(Cur_player_hp < pre_player_hp)
        {
            // 플레이어 피격 소리 여기다가 적어주세요.

            Hp_bar.value = Cur_player_hp;
            pre_player_hp = Cur_player_hp;

            PlayerPrefs.SetInt("PlayerHP", Cur_player_hp);
            PlayerPrefs.Save();
        }
    }
}
