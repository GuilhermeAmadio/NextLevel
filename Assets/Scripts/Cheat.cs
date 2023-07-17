using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EnemyStats[] enemies = FindObjectsOfType<EnemyStats>();
            foreach (EnemyStats enemy in enemies)
            {
                enemy.Die();
            }
        }
    }
}
