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
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform firePoint;

    private GameObject[] poolBullet;
    [SerializeField]  private Collider2D[] enemys;
    private GameObject targerToAttack;
    private float deltaTimeAttack;
    private Vector3 gunDirection;
    private float angleWeapon;
    private int countBulletInPool = 30;
    private int countBullet;

    private void Start()
    {
        // var temp = GameObject.FindObjectsOfType<DefenceBase>();
        objectDefence = FindObjectOfType<DefenceBase>().gameObject.transform;
        poolBullet = new GameObject[countBulletInPool];
        for (int i = 0; i < countBulletInPool; i++)
        {
            poolBullet[i] = (GameObject)Instantiate(bulletPrefab, new Vector3(0f, 0f, -10f), firePoint.rotation) as GameObject;         
            poolBullet[i].transform.parent = transform;
        }
    }

    private void FixedUpdate()
    {

        if (deltaTimeAttack <= 0)
        {
            
            deltaTimeAttack = timeBetweenAttack;
            enemys = Physics2D.OverlapCircleAll(transform.position, attackRange, attackMask);
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
                if ((targerToAttack != null) && (enemys.Length > 0))
                    AttackTarget(targerToAttack);
                
            }
        }
        if ((targerToAttack != null) && (enemys.Length > 0))
        {

            gunDirection = (targerToAttack.transform.position - weapon.position).normalized;
            //angleWeapon = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
            angleWeapon = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
            weapon.eulerAngles = new Vector3(0, 0, angleWeapon);
        }
            //Debug.Log(deltaTimeAttack);
            deltaTimeAttack -= Time.deltaTime;
    }

    void AttackTarget (GameObject target)
    {
        if ((countBullet > 0))
        {

            //onShot?.Invoke(this, EventArgs.Empty);
            poolBullet[countBullet - 1].transform.position = firePoint.position;

            // directionWeapon.z += UnityEngine.Random.Range(-dispersionBullet, dispersionBullet + 1);
            //Debug.Log(directionWeapon);
            poolBullet[countBullet - 1].transform.rotation = firePoint.rotation;//Quaternion.Euler(directionWeapon);
            poolBullet[countBullet - 1].SetActive(true);// plasmaBullet.ActivationBullet();
            countBullet--;
            //Invoke(nameof(LightOff), 0.1f);
        }
        else
            countBullet = countBulletInPool;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

