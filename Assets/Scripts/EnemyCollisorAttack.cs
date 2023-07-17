using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisorAttack : MonoBehaviour
{
    public EnemyStats stats;
    public CircleCollider2D coll;
    public bool canAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(stats.damage);
            canAttack = false;
        }
    }
}
