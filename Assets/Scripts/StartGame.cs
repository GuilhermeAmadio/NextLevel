using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartG()
    {
        Destroy(DontDestroy.instance.gameObject);
        SceneManager.LoadScene("Quimicka");
    }
}
