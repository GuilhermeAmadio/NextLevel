using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foice : MonoBehaviour
{
    public GameObject hit;
    public float damage;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Foice");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hit, collision.transform.position, Quaternion.identity);
            collision.GetComponent<IDamageable>().TakeDamage(damage, 8);
        }
    }
}
