using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHit : MonoBehaviour
{
    private Material originalMaterial;
    [SerializeField] private Material[] flashMaterial;
    private Coroutine flashRoutine;

    private void Awake()
    {
        originalMaterial = GetComponent<SpriteRenderer>().material;
    }

    public void Flash(int type)
    {
        if (flashRoutine == null)
        {
            StartCoroutine(FlashRoutine(type));
        }
    }

    private IEnumerator FlashRoutine(int type)
    {
        GetComponent<SpriteRenderer>().material = flashMaterial[type];
        yield return new WaitForSeconds(0.125f);
        GetComponent<SpriteRenderer>().material = originalMaterial;
        flashRoutine = null;
    }
}
