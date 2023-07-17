using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour, IDamageable
{
    public int life;
    public GameObject colectable;

    public void TakeDamage(float amount, int type)
    {
        life--;

        if (life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetTrigger("Destroy");
    }

    public void Drop()
    {
        Instantiate(colectable, transform.position, Quaternion.identity);
    }
}
