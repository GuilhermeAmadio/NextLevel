using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestoreScience : MonoBehaviour
{
    public Image element, backElement;

    private void Update()
    {
        if (element.fillAmount < 1f)
        {
            element.fillAmount += 0.05f * Time.deltaTime;
            backElement.fillAmount += 0.05f * Time.deltaTime;
        }
    }
}
