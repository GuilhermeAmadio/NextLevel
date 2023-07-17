using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo : MonoBehaviour
{
    public GameObject hit;
    public float damage, speed;
    public float endX;
    private float angle;
    private Vector3 direction;
    public Transform dir;
    public Rigidbody2D rb;
    private GameObject bola;

    private void Awake()
    {
        endX = transform.position.x + 20f;

        bola = FindObjectOfType<Bola>().gameObject;

        direction = bola.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        dir.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Wolf");
    }

    private void FixedUpdate()
    {
        rb.velocity = dir.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageable>().TakeDamage(damage, 7);
            Instantiate(hit, collision.transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Bola"))
        {
            Destroy(collision.gameObject);
            GetComponent<Animator>().SetTrigger("Ball");
        }
    }
}
