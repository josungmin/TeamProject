using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]

public class Dialogue
{
    [TextArea]
    public string dialogue;
    public Sprite bg;
    public Sprite character1;
    public Sprite character2;
}

public class eventdrive : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private SpriteRenderer character1;
    [SerializeField] private SpriteRenderer character2;
    [SerializeField] private Text textDialog;

    private bool isDialog = false;

    private bool fadevent1 = false;
    private bool fadevent2 = false;
    private bool fadevent3 = false;
    private bool fadevent4 = false;
    private bool fadevent5 = false;
    private bool fadevent6 = false;
    private bool fadevent7 = false;
    private bool fadevent8 = false;

    private int count = 0;

    [SerializeField] private Dialogue[] dialogues;

    public FadeManager fader;
    public FadeManager dialBoxFader;
    //public FadeManager character1Fader;
    //public FadeManager character2Fader;
    //public FadeManager character3Fader;
    public AudioPlay bgplayer;

    private void OnOff(bool _flag)
    {
        textDialog.gameObject.SetActive(_flag);

        isDialog = _flag;
    }

    public void ShowDialogue()
    {
        OnOff(true);

        count = 0;

        NextDialogue();
    }

    public void NextDialogue()
    {
        textDialog.text = dialogues[count].dialogue;
        bg.sprite = dialogues[count].bg;
        character1.sprite = dialogues[count].character1;
        character2.sprite = dialogues[count].character2;
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 27)
        {
            SceneManager.LoadScene("MainSceneF");
        }
        if (isDialog)
        {
            if (count < dialogues.Length)
            {
                NextDialogue();
            }
            else
                OnOff(false);
        }
        //fade in bg1
        if (count == 2)
        {
            if (!fadevent1)
            {
                bgplayer.startMusic();
                StartCoroutine(FadeinBG());
                fadevent1 = true;
            }
        }
        if (count == 3)
        {
            if (!fadevent7)
            {
                StartCoroutine(FadeoutBG());
                fadevent7 = true;
            }
        }
        //fade in bg2
        if (count == 4)
        {
            if (!fadevent2)
            {
                StartCoroutine(Fadein());
                fadevent2 = true;
            }
        }
        //fade in dalogue box & character
        if (count == 5)
        {
            if (!fadevent3)
            {
                StartCoroutine(FadeinDialogue());
                //StartCoroutine(FadeinCharacter1());
                //StartCoroutine(FadeinCharacter2());
                fadevent3 = true;
            }
        }
        /*
        if (count == 6)
        {
            if (!fadevent8)
            {
                StartCoroutine(FadeinCharacter3());
                StartCoroutine(FadeoutCharacter2());
                fadevent8 = true;
            }
        }
        */
        //장면 전환
        if (count == 19)
        {
            if (!fadevent4)
            {
                //StartCoroutine(FadeoutCharacter1());
                //StartCoroutine(FadeoutCharacter3());
                StartCoroutine(exchaingeBG());
                fadevent4 = true;
            }
        }
        if (count == 23)
        {
            if (!fadevent5)
            {
                StartCoroutine(exchaingeBG());
                //StartCoroutine(FadeinCharacter1());
                //StartCoroutine(FadeinCharacter3());
                fadevent5 = true;
            }
        }
        //fade out dalogue box & character
        if (count == 25)
        {
            if (!fadevent6)
            {
                StartCoroutine(Fadeout());
                StartCoroutine(FadeoutDialogue());
                //StartCoroutine(FadeoutCharacter1());
                //StartCoroutine(FadeoutCharacter3());
                fadevent6 = true;
            }
        }
    }
    //fade in bg1
    IEnumerator FadeinBG()
    {
        fader.FadeIn(2f);
        yield return new WaitForSeconds(5f);
        fader.FadeOut(4f);
    }
    //fade out bg1
    IEnumerator FadeoutBG()
    {
        fader.FadeOut(4f);
        yield return new WaitForSeconds(5f);
    }
    //fade in bg2
    IEnumerator Fadein()
    {
        fader.FadeIn(2f);
        yield return new WaitForSeconds(2f);
    }
    //fade out bg2
    IEnumerator Fadeout()
    {
        fader.FadeOut(2f);
        yield return new WaitForSeconds(2f);
    }
    //fade in dialogue box
    IEnumerator FadeinDialogue()
    {
        dialBoxFader.FadeOut(1f);
        yield return new WaitForSeconds(2f);
    }
    //장면전환
    IEnumerator exchaingeBG()
    {
        fader.FadeOut(0.5f);
        yield return new WaitForSeconds(1f);
        fader.FadeIn(1f);
    }
    //fade in dialogue box
    IEnumerator FadeoutDialogue()
    {
        dialBoxFader.FadeIn(1f);
        yield return new WaitForSeconds(2f);
    }
    /*
    //fade in Character1
    IEnumerator FadeinCharacter1()
    {
        character1Fader.FadeIn(1f);
        yield return new WaitForSeconds(2f);
    }
    //fade in Character2
    IEnumerator FadeinCharacter2()
    {
        character2Fader.FadeIn(1f);
        yield return new WaitForSeconds(2f);
    }
    //fade in Character3
    IEnumerator FadeinCharacter3()
    {
        character3Fader.FadeIn(1f);
        yield return new WaitForSeconds(2f);
    }
    //fade out Character1
    IEnumerator FadeoutCharacter1()
    {
        character1Fader.FadeOut(1f);
        yield return new WaitForSeconds(2f);
    }
    //fade out Character2
    IEnumerator FadeoutCharacter2()
    {
        character2Fader.FadeOut(1f);
        yield return new WaitForSeconds(2f);
    }
    //fade out Character3
    IEnumerator FadeoutCharacter3()
    {
        character3Fader.FadeOut(1f);
        yield return new WaitForSeconds(2f);
    }
    */
}
