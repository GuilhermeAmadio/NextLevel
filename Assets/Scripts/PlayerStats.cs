using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float[] damageFrascos, damageElements;
    public float life, lifeMax, speed, bulletForce, bulletForceFrasco;
    public bool canWalk, dead, shieldOn;
    public int numberOfFlashes;
    public float iFramesDuration;
    private bool invencible;
    public SpriteRenderer sprite;
    public ImagesFill barLife;
    public Animator anim;
    public BoxCollider2D coll;
    public GameObject shieldPrefab, gameOver;
    private GameObject shield;

    public void TakeDamage(float amount)
    {
        if (!invencible)
        {
            StartCoroutine(Invencible());
            if (shieldOn == false)
            {
                life -= amount;

                if (life <= 0)
                {
                    barLife.UpdateBar(0f, lifeMax);
                    FindObjectOfType<AudioManager>().Play("Morte");
                    Die();
                }
                else
                {
                    anim.SetTrigger("Damage");
                    FindObjectOfType<AudioManager>().Play("TakeHit");
                    barLife.UpdateBar(life, lifeMax);
                }
            } 
            else
            {
                shieldOn = false;
                shield.GetComponent<Animator>().SetTrigger("Destroy");
            }
        }
    }

    public void SpawnEscudo()
    {
        FindObjectOfType<AudioManager>().Play("ShieldAparecendo");
        shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
        shield.transform.SetParent(gameObject.transform);
        shieldOn = true;
    }

    public void RestoreLife(float amount)
    {
        life += amount;
        FindObjectOfType<AudioManager>().Play("Heal");

        if (life > lifeMax)
        {
            life = lifeMax;
        }

        barLife.UpdateBar(life, lifeMax);
    }

    private IEnumerator Invencible()
    {
        Physics2D.IgnoreLayerCollision(6, 10, true);
        invencible = true;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            sprite.color = new Color(1, 0, 0, 0.5f);
            //sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        invencible = false;
        Physics2D.IgnoreLayerCollision(6, 10, false);
    }

    public void CanWalk()
    {
        canWalk = true;
    }

    public void Die()
    {
        gameOver.SetActive(true);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        dead = true;
        coll.enabled = false;
        anim.SetTrigger("Die");
    }
}
