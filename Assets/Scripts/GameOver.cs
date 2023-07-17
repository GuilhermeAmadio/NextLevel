using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Start()
    {
        PauseGame.Instance.canotPause = true;
    }

    public void Menu()
    {
        Destroy(DontDestroy.instance.gameObject);
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Quimicka");
    }
}
