using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private bool doesDamage;
    [SerializeField] private bool damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("triger");
        //if (collision.gameObject.name != null)
           // Debug.Log(collision.gameObject.name);        
    }
    
}
