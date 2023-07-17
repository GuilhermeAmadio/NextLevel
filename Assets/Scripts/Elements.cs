using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    public GameObject element1, element2;
    public GameObject[] frasco, elementsAttack;
    public ImagesFill wBar, fBar, nBar, sBar;
    public PlayerStats stats;
    public Animator anim;
    public Transform spawnPoint, cuspirSpawnPoint, chaoSpawnPoint;
    public string attack;
    public bool element1Taken, element2Taken;
    public float wTotal, fTotal, nTotal, sTotal;

    private void Update()
    {
        if (stats.dead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartAttack("W");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            StartAttack("F");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            StartAttack("N");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            StartAttack("S");
        }
        else if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            StopCoroutine(WaitToResetAttack());
            ResetAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ConfirmeAttack();
        }

        wTotal += 0.05f * Time.deltaTime;
        fTotal += 0.05f * Time.deltaTime;
        nTotal += 0.05f * Time.deltaTime;
        sTotal += 0.05f * Time.deltaTime;

        if (wTotal > 1f)
        {
            wTotal = 1f;
        }

        if (fTotal > 1f)
        {
            fTotal = 1f;
        }

        if (nTotal > 1f)
        {
            nTotal = 1f;
        }

        if (sTotal > 1f)
        {
            sTotal = 1f;
        }
    }

    private void StartAttack(string attackChar)
    {
        if (!element1Taken || !element2Taken)
        {
            attack += attackChar;

            StopAllCoroutines();
            StartCoroutine(WaitToResetAttack());

            if (element1Taken)
            {
                SetElement(element2, attackChar);
                element2Taken = true;
            }
            else
            {
                SetElement(element1, attackChar);
                element1Taken = true;
            }
        }
    }

    private void SetElement(GameObject element, string attackChar)
    {
        element.SetActive(true);    
        if (attackChar == "W")
        {
            element.GetComponent<Animator>().SetTrigger("Water");
            FindObjectOfType<AudioManager>().Play("WaterSelect");
        }
        else if (attackChar == "F")
        {
            element.GetComponent<Animator>().SetTrigger("Fire");
            FindObjectOfType<AudioManager>().Play("FireSelect");
        }
        else if (attackChar == "N")
        {
            element.GetComponent<Animator>().SetTrigger("Nature");
            FindObjectOfType<AudioManager>().Play("NatureSelect");
        }
        else if (attackChar == "S")
        {
            element.GetComponent<Animator>().SetTrigger("Shadow");
            FindObjectOfType<AudioManager>().Play("DarkSelect");
        }
    }

    private void ConfirmeAttack()
    {
        anim.SetTrigger("Attack");
        stats.canWalk = false;
        Time.timeScale = 0.4f;
        PauseGame.Instance.canotPause = true;
        if (attack == "WW")
        {
            if (wTotal >= 0.35f)
            {
                anim.SetTrigger("Beber_Gelo");
                wTotal -= 0.35f;
                wBar.UpdateBar(wTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "WF" || attack == "FW")
        {
            if (wTotal >= 0.2f && fTotal >= 0.2f)
            {
                anim.SetTrigger("Beber_Pedra");
                wTotal -= 0.2f;
                fTotal -= 0.2f;
                wBar.UpdateBar(wTotal, 1f);
                fBar.UpdateBar(fTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "WN" || attack == "NW")
        {
            if (wTotal >= 0.5f && nTotal >= 0.5f)
            {
                anim.SetTrigger("Chão_Tsunami");
                wTotal -= 0.5f;
                nTotal -= 0.5f;
                wBar.UpdateBar(wTotal, 1f);
                nBar.UpdateBar(nTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "WS" || attack == "SW")
        {
            if (wTotal >= 0.5f && sTotal >= 0.5f)
            {
                anim.SetTrigger("Chão_Raio");
                wTotal -= 0.5f;
                sTotal -= 0.5f;
                wBar.UpdateBar(wTotal, 1f);
                sBar.UpdateBar(sTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "FF")
        {
            if (fTotal >= 0.5f)
            {
                anim.SetTrigger("Jogando_Lava");
                fTotal -= 0.5f;
                fBar.UpdateBar(fTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "FN" || attack == "NF")
        {
            if (fTotal >= 0.35f && nTotal >= 0.35f)
            {
                anim.SetTrigger("Jogando_Terremoto");
                fTotal -= 0.35f;
                nTotal -= 0.35f;
                fBar.UpdateBar(fTotal, 1f);
                nBar.UpdateBar(nTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "FS" || attack == "SF")
        {
            if (fTotal >= 0.2f && sTotal >= 0.2f)
            {
                anim.SetTrigger("Beber_Fogo");
                fTotal -= 0.2f;
                sTotal -= 0.2f;
                fBar.UpdateBar(fTotal, 1f);
                sBar.UpdateBar(sTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "NN")
        {
            if (nTotal >= 0.5f)
            {
                anim.SetTrigger("Beber_Escudo");
                nTotal -= 0.5f;
                nBar.UpdateBar(nTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "NS" || attack == "SN")
        {
            if (nTotal >= 0.5f && sTotal >= 0.5f)
            {
                anim.SetTrigger("Jogando_Lobo");
                nTotal -= 0.5f;
                sTotal -= 0.5f;
                nBar.UpdateBar(nTotal, 1f);
                sBar.UpdateBar(sTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "SS")
        {
            if (sTotal >= 0.35f)
            {
                anim.SetTrigger("Chão_Foice");
                sTotal -= 0.35f;
                sBar.UpdateBar(sTotal, 1f);
            }
            else
            {
                FrascoAttack(0);
            }
        }
        else if (attack == "")
        {
            
        }
        ResetAttack();
    }

    public void FrascoAttack(int index)
    {
        GameObject frascoObj = Instantiate(frasco[index], spawnPoint.position, Quaternion.identity);
        frascoObj.GetComponent<Bullet>().SetDamage(stats.damageFrascos[index]);
        frascoObj.GetComponent<Bullet>().FrascoBreak(transform.position.y - 1f);
        frascoObj.GetComponent<Rigidbody2D>().AddForce(spawnPoint.up * stats.bulletForceFrasco);
    }

    public void ElementToAttack(int index, Transform spawn)
    {
        GameObject elementObj = Instantiate(elementsAttack[index], spawn.position, Quaternion.identity);
        elementObj.GetComponent<Bullet>().SetDamage(stats.damageElements[index]);
        elementObj.GetComponent<Rigidbody2D>().velocity = spawnPoint.up * stats.bulletForce;
    }

    public void MisturaPoção()
    {
        FindObjectOfType<AudioManager>().Play("MisturaPoção");
    }

    public void Drink()
    {
        int n = Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play("Drink" + n);
    }

    private IEnumerator WaitToResetAttack()
    {
        yield return new WaitForSeconds(3f);
        ResetAttack();
    }

    private void ResetAttack()
    {
        attack = "";
        element1Taken = false;
        element2Taken = false;
        element1.SetActive(false);
        element2.SetActive(false);
    }

    public void Idle()
    {
        PauseGame.Instance.canotPause = false;
        anim.SetTrigger("Idle");
        Time.timeScale = 1f;
    }

    public void ResetTime()
    {
        Time.timeScale = 1f;
    }

    public void Escudo()
    {
        GetComponent<PlayerStats>().SpawnEscudo();
    }

    public void CuspirFogo()
    {
        int n = Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play("Cuspe" + n);
        ElementToAttack(2, cuspirSpawnPoint);
    }

    public void CuspirGelo()
    {
        int n = Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play("Cuspe" + n);
        ElementToAttack(0, cuspirSpawnPoint);
    }

    public void CuspirPedra()
    {
        int n = Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play("Cuspe" + n);
        ElementToAttack(1, cuspirSpawnPoint);
    }

    public void Tsunami()
    {
        ElementToAttack(3, chaoSpawnPoint);
    }

    public void Foice()
    {
        Instantiate(elementsAttack[4], chaoSpawnPoint.position, Quaternion.identity);
    }

    public void Raio()
    {
        Instantiate(elementsAttack[5], chaoSpawnPoint.position, Quaternion.identity);
    }

    public void Lava()
    {
        FrascoAttack(1);
    }

    public void Lobo()
    {
        FrascoAttack(2);
    }

    public void Terremoto()
    {
        FrascoAttack(3);
    }
}
