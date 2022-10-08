using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuController : MonoBehaviour
{
    [SerializeField] int _GameSceneIndex;
    public void PlayGame()
    {
        SceneManager.LoadScene(_GameSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
