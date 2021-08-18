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
    [SerializeField] private float timeScan = 0.2f;
    [SerializeField] private float debafSpeed = 2f;
    //private bool activ = true;
    //private MovementEnemy movementEnemy;
    //Collider2D targetCollider;
    private float deltaTimeAttack;
    private float deltaTimeScan;
    //private bool isAttack;

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        deltaTimeAttack = timeBetweenAttack;
        //isAttack = true;
        //targetCollider = collision;
        //Attack();
        //Invoke("Attack", 1f);
       // Invoke("Attack", 2f);

    }


    private void FixedUpdate()
    {

        if ( deltaTimeScan < 0)
        {

            deltaTimeScan = timeScan;
            Collider2D[] enemys = Physics2D.OverlapCircleAll (transform.position, attackRange, attackMask);
            ///Debug.Log(other.name);
            if (enemys != null)
            {
               // deltaTimeAttack = timeBetweenAttack;
                // Debug.Log(enemys.Length);
                foreach (var enemy in enemys)
                {
                    if (enemy.GetComponent<MovementEnemy>() != null)
                        enemy.GetComponent<MovementEnemy>().DebafSpeedMovement(debafSpeed,1f);
                }
            }
        }

        if (deltaTimeAttack < 0)
        {
            deltaTimeAttack = timeBetweenAttack;
            Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, attackRange, attackMask);
            if (enemys != null)
            {
                //deltaTimeAttack = timeBetweenAttack;
                Debug.Log("attack");
                foreach (var enemy in enemys)
                {
                    if (enemy.GetComponent<Health>() != null)
                        enemy.GetComponent<Health>().ApplyDamage(damag);
                }
            }
        }
           // Debug.Log(deltaTimeAttack);
            deltaTimeAttack -= Time.deltaTime;
            deltaTimeScan -= Time.deltaTime;
    }
    //void Attack ()
    //{

    //    if ((targetCollider.gameObject.GetComponent<Health>() != null) && (activ))
    //    {
    //        if (targetCollider.GetComponent<MovementEnemy>() != null)
    //            targetCollider.GetComponent<MovementEnemy>().DebafMovement();
    //        int targetHP = targetCollider.gameObject.GetComponent<Health>().CurrentHP;
    //        targetCollider.gameObject.GetComponent<Health>().ApplyDamage(currentDamage);
    //        amountDamage -= currentDamage;
    //        if (amountDamage <= 0)
    //        {
    //            activ = false;
    //            if (gameObject.GetComponent<BoxCollider2D>() != null)
    //                gameObject.GetComponent<BoxCollider2D>().enabled = false;
    //        }
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, attackRange);
    }
}
