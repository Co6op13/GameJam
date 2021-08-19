using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private bool isSpawn = false;
    [SerializeField] private int howMachZombiInPool = 30;
   // [SerializeField] private int howMachBigZombiInPool = 30;
    [SerializeField] private GameObject zombiPrefab;
    [SerializeField] private GameObject bigZombiPrefab;
    [SerializeField] private Transform parentObjectInIerarchi;   
    [SerializeField] private int currentEnemyInPool;
    private GameObject[] poolZombi;
    private GameObject[] poolBigZombi;
    private void Start()
    {
        currentEnemyInPool = howMachZombiInPool-1;
        parentObjectInIerarchi = gameObject.transform;
        poolZombi = new GameObject[howMachZombiInPool];
        for (int i = 0; i < howMachZombiInPool; i++)
        {
            poolZombi[i] = Instantiate(zombiPrefab, transform.position, transform.rotation);
            poolZombi[i].active = false;
            poolZombi[i].transform.SetParent(parentObjectInIerarchi);
        }

        
    }

    private void FixedUpdate()
    {
        
    }

    public void  SpawnEnemy()
    {
      
       while (isSpawn)
        {
            if (currentEnemyInPool < 1)
            {
                currentEnemyInPool = howMachZombiInPool;
            }
            Invoke("ActivationEnemy", 1f);
        }
    }

    void ActivationEnemy()
    {
        if (poolZombi[currentEnemyInPool].active != true)
        {
            poolZombi[currentEnemyInPool].active = true;
            poolZombi[currentEnemyInPool].gameObject.transform.position = transform.position;
            currentEnemyInPool--;
        }
    }
}
