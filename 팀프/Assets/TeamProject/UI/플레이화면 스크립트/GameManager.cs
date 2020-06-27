using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject ScanObject;
    public bool isAction;
    public Image portraitImg;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GameLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else menuSet.SetActive(true);
        }

        }

    public void GameSave()
    {

        PlayerPrefs.SetFloat("PlayerX",player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.Save();

        menuSet.SetActive(false);
        //플레이어 좌표
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float z = PlayerPrefs.GetFloat("PlayerZ");

        player.transform.position = new Vector3(x, y, z);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
