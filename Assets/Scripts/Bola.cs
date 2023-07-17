using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject lobo;

    private void Start()
    {
        float x = transform.position.x - 20;
        Instantiate(lobo, new Vector2(x , transform.position.y), Quaternion.identity);
    }
}
