using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfPit : MonoBehaviour
{
    [SerializeField] private int amountDamage = 20;
    private bool activ = true;
    [SerializeField] private bool isAttack = true;
    private MovementEnemy movementEnemy;
    [SerializeField] private bool isActiv = false;

    public void ActivScript()
    {
        isActiv = true;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActiv)
        {
            if (collision.gameObject.GetComponent<MovementEnemy>() != null)
            {
                collision.gameObject.GetComponent<MovementEnemy>().IsMovement = false;
            }

            if ((collision.gameObject.GetComponent<Health>() != null) && (activ))
            {

                if (isAttack)
                {
                    int targetHP = collision.gameObject.GetComponent<Health>().CurrentHP;
                    collision.gameObject.GetComponent<Health>().ApplyDamage(targetHP);
                    amountDamage--;
                }

                if (amountDamage <= 0)
                {
                    Destroy(gameObject);

                    //if (gameObject.GetComponent<BoxCollider2D>() != null)
                    //    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
}
