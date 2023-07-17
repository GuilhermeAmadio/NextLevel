using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipObj : MonoBehaviour
{
    public bool flipped;

    public void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        flipped = !flipped;
    }
}
