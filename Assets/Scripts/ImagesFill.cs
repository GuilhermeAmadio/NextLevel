using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesFill : MonoBehaviour
{
    public float chipSpeed = 2f, lerpTimer;
    public Image frontBar, backBar;
    public bool setBarBack, setBarFront;
    public float hFraction;

    private void Update()
    {
        if (setBarBack)
        {
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backBar.fillAmount = Mathf.Lerp(backBar.fillAmount, hFraction, percentComplete);

            if (backBar.fillAmount <= hFraction)
            {
                setBarBack = false;
            }
        }
        
        if (setBarFront)
        {
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontBar.fillAmount = Mathf.Lerp(frontBar.fillAmount, backBar.fillAmount, percentComplete);

            if (frontBar.fillAmount >= backBar.fillAmount)
            {
                setBarFront = false;
            }
        }
    }

    public void UpdateBar(float value1, float value2)
    {
        lerpTimer = 0f;
        hFraction = value1 / value2;

        if (backBar.fillAmount > hFraction)
        {
            setBarBack = true;
            frontBar.fillAmount = hFraction;
            //backBar.color = Color.yellow;
        }
        else if (backBar.fillAmount < hFraction)
        {
            setBarFront = true;
            backBar.fillAmount = hFraction;
            //backBar.color = Color.green;
        }
    }
}
