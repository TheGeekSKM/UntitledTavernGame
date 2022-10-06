using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuController : MonoBehaviour
{
    [SerializeField] string _GameSceneName;
    public void PlayGame()
    {
        SceneManager.LoadScene(_GameSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
