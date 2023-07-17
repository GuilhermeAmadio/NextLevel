using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject hit;
    public float damage;
    private bool stop;
    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    private void Update()
    {
        if (enemies.Count > 0)
        {
            if (stop == false)
            {
                stop = true;
                StartCoroutine(DealDamage());
            }
        }
        else
        {
            StopCoroutine(DealDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemies.Remove(collision.gameObject);
        }
    }

    private IEnumerator DealDamage()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].GetComponent<IDamageable>().TakeDamage(damage, 4);
                Instantiate(hit, enemies[i].transform.position, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(0.5f);
        stop = false;
    }

    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetTrigger("Destroy");
    }
}
