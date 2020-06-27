using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    private static MainGameManager _instance = null;

    public static MainGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (MainGameManager)FindObjectOfType(typeof(MainGameManager));
                if (_instance == null)
                {
                    Debug.Log("There's no active ManagerClass object");
                }
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // 임시
        if (!PlayerPrefs.HasKey("once"))
        {
            PlayerPrefs.SetInt("PlayerHP", 100);
            PlayerPrefs.Save();

            PlayerPrefs.SetFloat("playerXpos", 44.0f);
            PlayerPrefs.SetFloat("playerYpos", 1.0f);
            PlayerPrefs.SetFloat("playerZpos", 28.0f);

            PlayerPrefs.Save();

            PlayerPrefs.SetInt("Enemy1_Alive", 1);
            PlayerPrefs.SetInt("Enemy2_Alive", 1);
            PlayerPrefs.SetInt("Enemy3_Alive", 1);
            PlayerPrefs.SetInt("Enemy4_Alive", 1);
            PlayerPrefs.SetInt("Enemy5_Alive", 1);

            PlayerPrefs.Save();

            PlayerPrefs.SetFloat("enemy1_xPos", 0.0f);
            PlayerPrefs.SetFloat("enemy1_yPos", 1.0f);
            PlayerPrefs.SetFloat("enemy1_zPos", 0.0f);

            PlayerPrefs.Save();

            PlayerPrefs.SetFloat("enemy2_xPos", 15.0f);
            PlayerPrefs.SetFloat("enemy2_yPos", 1.0f);
            PlayerPrefs.SetFloat("enemy2_zPos", 0.0f);

            PlayerPrefs.Save();

            PlayerPrefs.SetFloat("enemy3_xPos", 15.0f);
            PlayerPrefs.SetFloat("enemy3_yPos", 1.0f);
            PlayerPrefs.SetFloat("enemy3_zPos", 11.0f);

            PlayerPrefs.Save();

            PlayerPrefs.SetFloat("enemy4_xPos", 25.0f);
            PlayerPrefs.SetFloat("enemy4_yPos", 1.0f);
            PlayerPrefs.SetFloat("enemy4_zPos", 11.0f);

            PlayerPrefs.Save();

            PlayerPrefs.SetFloat("enemy5_xPos", 38.0f);
            PlayerPrefs.SetFloat("enemy5_yPos", 1.0f);
            PlayerPrefs.SetFloat("enemy5_zPos", 12.0f);

            PlayerPrefs.Save();

            PlayerPrefs.SetInt("once", 1);

            PlayerPrefs.Save();

            PlayerPrefs.SetFloat("playerXpos", 44.0f);
            PlayerPrefs.SetFloat("playerYpos", 1.0f);
            PlayerPrefs.SetFloat("playerZpos", 28.0f);

            PlayerPrefs.Save();
        }
    }
}
