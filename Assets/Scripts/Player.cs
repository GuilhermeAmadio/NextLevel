using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;
    public Rigidbody2D rb;
    public FlipObj flip;
    public Animator anim;
    private Vector2 movement;
    private bool paused;

    void Update()
    {
        if (stats.dead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if ((movement.x > 0 && flip.flipped) || movement.x < 0 && !flip.flipped)
        {
            flip.Flip();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                anim.updateMode = AnimatorUpdateMode.UnscaledTime;
                paused = false;
            }
            else
            {
                anim.updateMode = AnimatorUpdateMode.Normal;
                paused = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (stats.dead)
        {
            return;
        }

        if (stats.canWalk)
        {
            rb.MovePosition(rb.position + movement.normalized * stats.speed * Time.fixedDeltaTime);
        }
    }
}
