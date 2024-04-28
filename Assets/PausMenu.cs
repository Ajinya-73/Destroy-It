using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;

    }

    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void Home(int sceneID)
    {

        
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneID);

    }
}
