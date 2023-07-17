using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hit;
    public FrascoBreak fBreak;
    private float damage, yPosBreak;
    public int type;
    private bool frasco;
    public string soundName;
    public int soundVariation;
    public bool dontDestroy, dontDealDamage;
    public string startSound;

    private void Start()
    {
        if (startSound != null)
        {
            FindObjectOfType<AudioManager>().Play(startSound);
        }
    }

    public void SetDamage(float amount)
    {
        damage = amount;
    }

    public void FrascoBreak(float yPos)
    {
        frasco = true;
        yPosBreak = yPos;
    }

    private void Update()
    {
        if (!frasco)
        {
            return;
        }

        if (transform.position.y <= yPosBreak)
        {
            Instantiate(hit, transform.position, Quaternion.identity);
            fBreak.Break();
            Break();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hit, collision.transform.position, Quaternion.identity);
            if (!dontDealDamage)
            {
                collision.GetComponent<IDamageable>().TakeDamage(damage, type);
            }

            if (frasco)
            {
                fBreak.Break();
            }

            Break();
        }
    }

    private void Break()
    {
        if (soundName != null)
        {
            int n = Random.Range(1, soundVariation + 1);
            FindObjectOfType<AudioManager>().Play(soundName + n);
        }
        if (!dontDestroy)
        {
            Destroy(gameObject);
        }
    }
}
