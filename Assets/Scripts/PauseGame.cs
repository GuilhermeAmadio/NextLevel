using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static PauseGame Instance { get; private set; }

    public static bool gameIsPaused = false;
    public bool canotPause;

    public GameObject pauseMenuUI, tutorial, tutorialVoltar;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canotPause == false)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else if (!gameIsPaused)
            {
                Pause();
            }
        }

    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Menu()
    {
        Destroy(DontDestroy.instance.gameObject);
        SceneManager.LoadScene("Menu");
    } 

    public void Tutorial()
    {
        tutorial.SetActive(true);
        tutorialVoltar.SetActive(true);
    }

    public void Voltar()
    {
        tutorial.SetActive(false);
        tutorialVoltar.SetActive(false);
    }
}
