using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject flecha;
    public GameObject[] cameras, paredes;
    private int index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            flecha.SetActive(false);
            paredes[index].SetActive(false);
            cameras[index].SetActive(false);
            index++;
            cameras[index].SetActive(true);
            paredes[index].SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
