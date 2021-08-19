using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private LayerMask attackMask;
    [SerializeField] private float rangeExplosion = 3f;
    [SerializeField] private GameObject prefabExplosion;
   // [SerializeField] private int damage = 30;
    //[SerializeField] private float timeStun = 3f;
    // Start is called before the first frame update
    
    private void StartExplosion()
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(transform.position, rangeExplosion, attackMask);

        foreach (var enemy in enemys )
        {
            Rigidbody2D rigidbody = enemy.attachedRigidbody;
            if (rigidbody)
            {
                enemy.GetComponent<MovementEnemy>().DebafSpeedMovement(0.1f, 3f);
                enemy.GetComponent<MovementEnemy>().IsMovement = false;
                Debug.Log("test");
                var force = enemy.transform.position - transform.position;
                rigidbody.AddForce(( force ) * 3f, ForceMode2D.Impulse);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("BAAAANG");
        StartExplosion();
    }
}
