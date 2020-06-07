using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

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
                if (isSound)
                {
                    isSound = !isSound;
                    Debug.Log("Sound Off");
                }
                else
                {
                    isSound = !isSound;
                    Debug.Log("Sound ON");
                }
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("그만두기");
                break;
        }
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
