using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRest : MonoBehaviour
{
    public Boss stats;
    public Rigidbody2D rb;
    public Animator anim;
    public EnemyCollisorAttack coll;
    public FlipObj flip;
    private GameObject player;

    private float angle;
    public bool canWalk, attacking;
    public Transform dir;
    private Vector3 direction;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>().gameObject;
    }

    private void Update()
    {
        if (stats.dead)
        {
            return;
        }

        direction = player.transform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        dir.rotation = Quaternion.Euler(0, 0, angle);

        if (Vector2.Distance(player.transform.position, transform.position) <= stats.range)
        {
            canWalk = false;
            if (stats.cd <= 0)
            {
                Attack();
            }
        }
        else
        {
            if (!attacking)
            {
                canWalk = true;
            }
        }

        if ((player.transform.position.x < transform.position.x && flip.flipped) || player.transform.position.x > transform.position.x && !flip.flipped)
        {
            flip.Flip();
        }
    }

    private void FixedUpdate()
    {
        if (stats.dead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (canWalk)
        {
            rb.velocity = dir.up * stats.speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Attack()
    {
        attacking = true;
        coll.canAttack = true;
        canWalk = false;
        anim.SetTrigger("Attack");
        stats.cd = stats.cdMax;
    }

    public void EndAttack()
    {
        attacking = false;
    }
}
