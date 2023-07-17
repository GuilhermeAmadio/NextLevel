using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class EnemyStats : MonoBehaviour, IDamageable
{
    public float life, lifeMax, damage, speed, range, cd, cdMax;
    public string fraqueza, normal, forte;
    public bool dead;
    public FlashHit flash;
    public ShowText show;
    private Animator anim;
    public Sprite face, lifeSprite;
    public Color32[] colors;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
    }

    public void TakeDamage(float amount, int type)
    {
        if (type != 9)
        {
            EnemyFaceUI.instance.ShowLife(face, lifeSprite, life / lifeMax);
            float realAmount = 0f;

            if (CheckDamage(fraqueza, type.ToString()))
            {
                realAmount = amount + (amount * 0.5f);
            }
            else if (CheckDamage(normal, type.ToString()))
            {
                realAmount = amount;
            }
            else if (CheckDamage(forte, type.ToString()))
            {
                realAmount = amount - (amount * 0.5f);
            }
            else
            {
                realAmount = 0f;
            }

            life -= realAmount;
            if (realAmount > 0)
            {
                flash.Flash(type);
                show.Show((realAmount * 10).ToString(), 10f);
            }
            else
            {
                show.Show("IMUNE", 10f);
            }

            if (life <= 0)
            {
                Die();
            }
            EnemyFaceUI.instance.UpdateLife(life, lifeMax);
        }
    }

    private bool CheckDamage(string compareString, string type)
    {
        foreach (char letra in compareString)
        {
            if (type[0] == letra)
            {
                return true;
            }
        }

        return false;
    }

    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        GetComponent<BoxCollider2D>().enabled = false;
        Spawner.instance.LessEnemy();
        dead = true;
        anim.SetTrigger("Death");
    }
}
