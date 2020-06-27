using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup OptionGroup;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    bool isSound;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                SceneLoader.LoadSceneHandle("Play", 0);
                break;
            case BTNType.Continue:
                SceneLoader.LoadSceneHandle("Play", 1);
                break;
            case BTNType.Sound:
                CanvasGroupOn(OptionGroup);
                CanvasGroupOff(mainGroup);
                break;

            case BTNType.Quit:
                Application.Quit();
                Debug.Log("그만두기");
                break;

            case BTNType.Back:
                CanvasGroupOff(OptionGroup);
                CanvasGroupOn(mainGroup);
                break;

        }
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

}
