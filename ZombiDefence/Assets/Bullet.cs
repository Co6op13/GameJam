using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(5f, 50f)] [SerializeField] private float speed;
    [SerializeField] private BoxCollider2D collider2D;
    //[SerializeField] private Vector3 weaponBar = new Vector3(0f, 0f, -10);
    [Range(1f, 30f)] [SerializeField] private int damage = 1;

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        //Debug.Log(transform.rotation);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombi>() != null)
        {
               Debug.Log("test");
            gameObject.SetActive(false);
            transform.position = new Vector3(0, 0, -100);

            if (collision.gameObject.GetComponent<Health>() != null)
            {
                collision.gameObject.GetComponent<Health>().ApplyDamage(damage);
                //Debug.Log("damaged"+collision.gameObject.name);
            }
        }
    }
}
