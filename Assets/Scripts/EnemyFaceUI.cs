using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFaceUI : MonoBehaviour
{
    public static EnemyFaceUI instance;
    public GameObject all;
    public Image face, vida, backVida;
    public ImagesFill imageFill;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void ShowLife(Sprite newFace, Sprite newLifeSprite, float originalValue)
    {
        if (face.sprite != newFace)
        {
            face.sprite = newFace;
            vida.sprite = newLifeSprite;

            vida.fillAmount = originalValue;
            backVida.fillAmount = originalValue;
        }

        if (!all.activeSelf)
        {
            all.SetActive(true);
        }
    }

    public void UpdateLife(float value1, float value2)
    {
        imageFill.UpdateBar(value1, value2);

        if (value1 <= 0)
        {
            all.SetActive(false);
        }
    }
}
