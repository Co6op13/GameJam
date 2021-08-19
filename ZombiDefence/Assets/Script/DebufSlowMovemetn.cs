using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebufSlowMovemetn : MonoBehaviour
{//  [SerializeField] private int amountDamage = 100;
    [SerializeField] private LayerMask attackMask;
    [SerializeField] private float attackRange = 2f;
   // [SerializeField] private int damag = 1;
   // [SerializeField] private float timeBetweenAttack = 1f;
    [SerializeField] private float timeScan = 0.2f;
    [SerializeField] private float debafSpeed = 2f;

    private float deltaTimeScan;



    private void FixedUpdate()
    {

        if (deltaTimeScan < 0)
        {

            deltaTimeScan = timeScan;
            Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, attackRange, attackMask);
            ///Debug.Log(other.name);
            if (enemys != null)
            {
                // deltaTimeAttack = timeBetweenAttack;
                // Debug.Log(enemys.Length);
                foreach (var enemy in enemys)
                {
                    if (enemy.GetComponent<MovementEnemy>() != null)
                        enemy.GetComponent<MovementEnemy>().DebafSpeedMovement(debafSpeed, 1f);
                }
            }
        }
        deltaTimeScan -= Time.deltaTime;
    }
}
