using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPit : MonoBehaviour
{
    [SerializeField] private int amountDamage = 100;
    private bool activ = true;
    [SerializeField] private bool isAttack = true;
    private MovementEnemy movementEnemy;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<MovementEnemy>() != null )
        {
            collision.gameObject.GetComponent<MovementEnemy>().IsMovement = false;
        }

        if ((collision.gameObject.GetComponent<Health>() != null)&& (activ))
        {

            if (isAttack)
            {
                int targetHP = collision.gameObject.GetComponent<Health>().CurrentHP;
                collision.gameObject.GetComponent<Health>().ApplyDamage(targetHP);
                amountDamage -= targetHP;
            }
            
            if (amountDamage <= 0)
            {
                activ = false;
                if (gameObject.GetComponent<BoxCollider2D>() != null)
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        
    }
}
