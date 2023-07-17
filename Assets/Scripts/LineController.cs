using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject hit;
    public LineRenderer lR;
    public Texture[] textures;

    private int animationStep;
    public float fps = 30f;
    private float fpsCounter;
    public float timeBetweenHit;
    private bool canHit = true;
    public float damage;

    private Transform target;

    public void AssignTarget(Vector3 startPos, Transform newTarget)
    {
        lR.positionCount = 2;
        lR.SetPosition(0, startPos);
        target = newTarget;
    }

    private void Update()
    {
        lR.SetPosition(1, target.position);

        if (canHit)
        {
            StartCoroutine(DealDamage());
            target.GetComponent<IDamageable>().TakeDamage(damage, 3);
            Instantiate(hit, target.transform.position, Quaternion.identity);
        }

        fpsCounter += Time.deltaTime;
        if (fpsCounter >= 1f / fps)
        {
            animationStep++;
            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }

            lR.material.SetTexture("_MainTex", textures[animationStep]);
            fpsCounter = 0f;
        }
    }

    private IEnumerator DealDamage()
    {
        canHit = false;

        yield return new WaitForSeconds(timeBetweenHit);

        canHit = true;
    }
}
