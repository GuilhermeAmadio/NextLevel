using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringsShowText : MonoBehaviour
{
    public string text;

    public void ShowStringText()
    {
        GetComponent<TMPro.TextMeshPro>().text = text;
    }
}
