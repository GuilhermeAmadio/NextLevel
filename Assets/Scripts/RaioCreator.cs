using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaioCreator : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    public List<LineController> allLines = new List<LineController>();
    public LineController line;

    private void Start()
    {
        StartCoroutine(DestroyAfterSecond());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!enemys.Contains(collision.gameObject))
            {
                enemys.Add(collision.gameObject);
                CreateNewLine(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (enemys.Contains(collision.gameObject))
            {
                GameObject lineToEnemy = allLines[enemys.IndexOf(collision.gameObject)].gameObject;
                allLines.Remove(allLines[enemys.IndexOf(collision.gameObject)]);
                Destroy(lineToEnemy);
                enemys.Remove(collision.gameObject);
            }
        }
    }

    private void CreateNewLine(GameObject enemy)
    {
        LineController newLine = Instantiate(line);
        allLines.Add(newLine);

        newLine.AssignTarget(transform.position, enemy.transform);
    }

    private IEnumerator DestroyAfterSecond()
    {
        yield return new WaitForSeconds(3f);

        for (int i = allLines.Count; i > 0; i--)
        {
            GameObject lineEnemy = allLines[i-1].gameObject;
            allLines.Remove(allLines[i-1]);
            Destroy(lineEnemy);
        }

        Destroy(gameObject);
    }
}
