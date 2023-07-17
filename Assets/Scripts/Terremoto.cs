using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terremoto : MonoBehaviour
{
    public GameObject hit;
    public float damage;

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("Tremor");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            collision.GetComponent<IDamageable>().TakeDamage(damage, 5);
            Instantiate(hit, collision.transform.position, Quaternion.identity);
        }
    }
}
