using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{

    [SerializeField] private int howMachZombiInPool = 30;
    [SerializeField] private int howMachBigZombiInPool = 30;
    [SerializeField] private GameObject zombiPrefab;
    [SerializeField] private GameObject bigZombiPrefab;
    [SerializeField] private Transform parentObjectInIerarchi;
    private GameObject[] poolZombi;
    private GameObject[] poolBigZombi;
    private void Start()
    {
        parentObjectInIerarchi = GameObject.FindObjectOfType<EnemyList>().transform;
        poolZombi = new GameObject[howMachZombiInPool];
        for (int i = 0; i < howMachZombiInPool; i++)
        {
            poolZombi[i] = Instantiate(zombiPrefab, transform.position, transform.rotation);
            ///poolZombi[i].active = false;
            poolZombi[i].transform.SetParent(parentObjectInIerarchi);
        }
    }



}
