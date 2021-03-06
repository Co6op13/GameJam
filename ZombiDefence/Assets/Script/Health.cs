using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHP = 10;
    [SerializeField] private int currentHP = 0;
    [SerializeField] private GameObject prefabDie;
    [SerializeField] private bool ifBase = false;
    [SerializeField] private GameObject gameOwer;

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

    void Die()
    {
        if (gameObject != null)
        {
            if (prefabDie != null)
            {
                if (ifBase)
                {
                    gameOwer.GetComponent<TextMeshProUGUI>().enabled = true; ;
                    //gameOwer.gameObject.e enable = true;
                }

                var dieAnimation = Instantiate(prefabDie, transform.position, transform.rotation);
                var cuurentGFX = gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
                //Debug.Log(cuurentGFX.name);
                var dieGFX = dieAnimation.GetComponentInChildren<SpriteRenderer>();
                dieGFX.sprite = cuurentGFX;

            }

            Destroy(gameObject);
            //gameObject.active = false;

        }
    }

    private void OnDestroy()
    {
        if (ifBase)
        {
            gameOwer.GetComponent<TextMeshProUGUI>().enabled = true; ;
            //gameOwer.gameObject.e enable = true;
        }

    }
}
