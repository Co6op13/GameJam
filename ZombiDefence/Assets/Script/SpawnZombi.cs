using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombi : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsEnemys;
    [SerializeField] private int maxEnemyOnScreen = 10;
    [SerializeField] private int totalEnemy = 50;
    [SerializeField] private int enemySpawninOneTime = 1;

    [SerializeField] private float spawnDelay = 0.5f;
    int countEnemyOnScreen = 0;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        if (enemySpawninOneTime > 0 && countEnemyOnScreen < maxEnemyOnScreen)
        {
            for (int i=0; i < enemySpawninOneTime; i++)
            {
                if (countEnemyOnScreen < maxEnemyOnScreen)
                {
                    GameObject newEnemy;
                    int typeEnemy = Random.Range(0, 100);
                    if (i >= 0 && i <= 40)
                    {
                        newEnemy = Instantiate(prefabsEnemys[0]) as GameObject;
                        SetParameterNewEnemy(newEnemy);
                    }
                    if (i >= 0 && i <= 40)
                    {
                        newEnemy = Instantiate(prefabsEnemys[1]) as GameObject;
                        SetParameterNewEnemy(newEnemy);
                    }
                    if (i >= 0 && i <= 40)
                    {
                        newEnemy = Instantiate(prefabsEnemys[2]) as GameObject;
                        SetParameterNewEnemy(newEnemy);
                    }
                    if (i >= 0 && i <= 40)
                    {
                        newEnemy = Instantiate(prefabsEnemys[3]) as GameObject;
                        SetParameterNewEnemy(newEnemy);
                    }
                    countEnemyOnScreen++;
                }
            }
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(Spawn());
        }
    }

    void SetParameterNewEnemy(GameObject enemy)
    {
        enemy.transform.position = transform.position;
        enemy.active = true;
        enemy.GetComponent<Health>().SetHP();
    }
}
