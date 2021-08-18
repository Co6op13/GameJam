using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private LayerMask attackMask;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float timeBetweenAttack = 1f;
    [SerializeField] private int damag = 1;
    [SerializeField] private MovementEnemy movementEnemy;
   
    private float tempTime;
    private bool isAttack;

    private void Start()
    {
        tempTime = 0f;
        movementEnemy = GetComponent<MovementEnemy>();
    }

    private void FixedUpdate()
    {
        if ((isAttack) & (tempTime <= 0))
        {
            tempTime = timeBetweenAttack;
            Collider2D other = Physics2D.OverlapCircle(transform.position, attackRange, attackMask);
            ///Debug.Log(other.name);
            if (other != null)
                if (other.gameObject.GetComponent<Health>() != null)
                {
                    other.GetComponent<Health>().ApplyDamage(damag);
                    if (other.GetComponent<Health>().isAlive == false)
                    {
                        isAttack = false;
                        movementEnemy.IsMovement = true;
                    }
                }
        }
        else if (tempTime > 0)
        {
            tempTime -= Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Obstacle>() != null)
        {
            Debug.Log("обнаружено препятствие... атакуем");
            isAttack = true;
            movementEnemy.IsMovement = false;
        }
    }


}
