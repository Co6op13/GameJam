using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHP = 10;
    [SerializeField] private int currentHP = 0;

    public bool isAlive => currentHP > 0;

     public int CurrentHP {  get => currentHP; }

    private void Start()
    {
        currentHP = maxHP;
    }
    // private int HealthPoint { get => healthPoint; set => healthPoint = value; }

    public void SetHP()
    {
        currentHP = maxHP;
    }

    void ApplyHeall (int heall)
    {
        if (heall > 0)
        {
            if (CurrentHP+ heall > maxHP)
                currentHP = maxHP;
            else                
                currentHP += heall;            
        }
    }

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
        {
            currentHP -= damage;
        }

        if (!isAlive)
            Die();
    }

    void Die ()
    {
        if (gameObject != null)
        gameObject.active = false;
    }
}
