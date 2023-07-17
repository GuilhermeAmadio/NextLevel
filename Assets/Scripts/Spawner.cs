using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject flecha, youWon;
    public int enemysAlive, index, maxHorda;
    public Horda[] horda;
    public GameObject[] parede;
    public int[] numberHordas;
    public int numberHordasAtual;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < horda[index].enemys.Length; i++)
        {
            Instantiate(horda[index].enemys[i], horda[index].spawnPoints[i].position, Quaternion.identity);
            enemysAlive++;
        }
    }

    public void LessEnemy()
    {
        enemysAlive--;

        if (enemysAlive <= 0)
        {
            MoreIndex();
            if (index <= numberHordas[numberHordasAtual])
            {
                Spawn();
            }
            else
            {
                parede[numberHordasAtual].SetActive(false);
                numberHordasAtual++;
                flecha.SetActive(true);

                if (numberHordasAtual == maxHorda)
                {
                    flecha.SetActive(false);
                    parede[numberHordasAtual-1].SetActive(true);
                    youWon.SetActive(true);
                }
            }
        }
    }

    public void MoreIndex()
    {
        index++;
    }
}
