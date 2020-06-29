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
}

public class eventdrive : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private Text textDialog;

    private bool isDialog = false;

    private bool fadevent1 = false;
    private bool fadevent2 = false;
    private bool fadevent3 = false;
    private bool fadevent4 = false;
    private bool fadevent5 = false;
    private bool fadevent6 = false;

    private int count = 0;

    [SerializeField] private Dialogue[] dialogues;

    public FadeManager fader;
    public FadeManager dialBoxFader;
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
                StartCoroutine(FadeEvent());
                fadevent1 = true;
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
        //fade in dalogue box
        if (count == 5)
        {
            if (!fadevent3)
            {
                StartCoroutine(FadeinDialogue());
                fadevent3 = true;
            }
        }
        //장면 전환
        if (count == 19)
        {
            if (!fadevent4)
            {
                StartCoroutine(exchaingeBG());
                fadevent4 = true;
            }
        }
        if (count == 23)
        {
            if (!fadevent5)
            {
                StartCoroutine(exchaingeBG());
                fadevent5 = true;
            }
        }
        //fade out dalogue box
        if (count == 25)
        {
            if (!fadevent6)
            {
                StartCoroutine(Fadeout());
                StartCoroutine(FadeoutDialogue());
                fadevent6 = true;
            }
        }
    }
    //fade in bg1
    IEnumerator FadeEvent()
    {
        fader.FadeIn(2f);
        yield return new WaitForSeconds(5f);
        fader.FadeOut(4f);
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
}
