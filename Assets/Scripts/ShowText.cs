using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] GameObject damageTaken;
    [SerializeField] private float minX, maxX, minY, maxY;

    public void Show(string text, float fontSize)
    {
        GameObject aux = Instantiate(damageTaken, new Vector2(transform.position.x + Random.Range(minX, maxX), transform.position.y + Random.Range(minY, maxY)), Quaternion.identity);
        aux.GetComponentInChildren<StringsShowText>().text = text;
        aux.GetComponentInChildren<TMPro.TextMeshPro>().fontSize = fontSize;
        aux.GetComponentInChildren<StringsShowText>().ShowStringText();
    }
}
