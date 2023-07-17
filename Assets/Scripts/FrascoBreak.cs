using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrascoBreak : MonoBehaviour
{
    public GameObject obj;

    public void Break()
    {
        if (obj != null)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
        }
    }
}
