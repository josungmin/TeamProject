using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Savebtn : MonoBehaviour
{
    public void SaveBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
