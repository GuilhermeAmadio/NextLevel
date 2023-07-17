using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotationBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Vector2 movement;

    void Start()
    {
        movement = rb.velocity;

        if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
