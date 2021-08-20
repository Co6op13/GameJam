using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    //  [SerializeField] private int amountDamage = 100;
    [SerializeField] private LayerMask attackMask;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private int damag = 1;
    [SerializeField] private float timeBetweenAttack = 1f;
    [SerializeField] private bool isActiv = false;
    //[SerializeField] private float timeScan = 0.2f;
    //[SerializeField] private float debafSpeed = 2f;
    //private bool activ = true;
    //private MovementEnemy movementEnemy;
    //Collider2D targetCollider;
    private float deltaTimeAttack;
   // private float deltaTimeScan;
    //private bool isAttack;

    


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    deltaTimeAttack = timeBetweenAttack;
    //}

    public void ActivScript()
    {
        isActiv = true;
    }


    private void FixedUpdate()
    {
        if (isActiv)
        {

            if (deltaTimeAttack < 0)
            {
                deltaTimeAttack = timeBetweenAttack;
                Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, attackRange, attackMask);
                if (enemys != null)
                {
                    //deltaTimeAttack = timeBetweenAttack;
                    // Debug.Log("attack");
                    foreach (var enemy in enemys)
                    {
                        if (enemy.GetComponent<Health>() != null)
                            enemy.GetComponent<Health>().ApplyDamage(damag);
                    }
                }
            }
            // Debug.Log(deltaTimeAttack);
            deltaTimeAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, attackRange);
    }
}
