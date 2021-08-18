using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateShooting : MonoBehaviour
{
    [SerializeField] private LayerMask attackMask;
    [SerializeField] private int damag = 1;
    [SerializeField] private float timeBetweenAttack = 0.2f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform objectDefence;
    private GameObject targerToAttack;
    private float deltaTimeAttack;

    private void FixedUpdate()
    {
        if (deltaTimeAttack <= 0)
        {
            deltaTimeAttack = timeBetweenAttack;
            Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, attackRange, attackMask);
            ///Debug.Log(other.name);
            if (enemys != null)
            {
                float distance = 99f;
               foreach ( var enemy in enemys)
                {
                    if (Vector2.Distance(enemy.transform.position, objectDefence.position)<  distance)
                    {                        
                        distance = Vector2.Distance(enemy.transform.position, objectDefence.position);
                        targerToAttack = enemy.gameObject;
                    }
                }
                AttackTarget(targerToAttack);
            }
        }

        deltaTimeAttack -= Time.deltaTime;
    }

    void AttackTarget (GameObject target)
    {

    }


}

