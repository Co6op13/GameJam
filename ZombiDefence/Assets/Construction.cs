using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Construction : MonoBehaviour
{
    [SerializeField] private GameObject PlaceWhereConstruction;
    [SerializeField] private Transform[] constructionPoints;
   // [SerializeField] private GameObject listBlink;
    //[SerializeField] private GameManager gameManager;
    //[SerializeField] private Transform[] animationBlinkList;
    //public event EventHandler onChangeHP;
    private Thorns thorns;
    private WolfPit WolfPit;
    private Health health;
    private DebufSlowMovemetn DebufSlowMovemetn;

    
    //[SerializeField] private GameObject[] activScriptOnThisGameObject; 
    private bool isActiv = false;

    private void Start()
    {
        FindObjectOfType<GameManager>().CurentCardMinus();
        if ( GetComponent<Thorns>() != null)
            thorns = GetComponent<Thorns>();
        if (GetComponent<WolfPit>() != null)
            WolfPit = GetComponent<WolfPit>();
        if (GetComponent<Health>() != null)
            health = GetComponent<Health>();
        if (GetComponent<DebufSlowMovemetn>() != null)
            DebufSlowMovemetn  = GetComponent<DebufSlowMovemetn>();
       // animationBlinkList = listBlink.GetComponentsInChildren<Transform>();
        constructionPoints = PlaceWhereConstruction.GetComponentsInChildren<Transform>();
        //if (animationBlinkList.Length >0)
        //{
        //    foreach (var anim in animationBlinkList)
        //    {
        //        anim
        //    }
        //}

    }
    // Start is called before the first frame update
    private void Update()
    {
                constructionPoints = PlaceWhereConstruction.GetComponentsInChildren<Transform>();
        if (Input.GetMouseButtonDown(0))
        {
            CheckPlaceConstruction();
        }
        if (!isActiv)
        {
            WhereConstruction();
        }
    }
    void WhereConstruction()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;


    }

    void CheckPlaceConstruction()
    {
        //Debug.Log("1");
        foreach (var point in constructionPoints)
        {
            
               

            if (Vector2.Distance(transform.position, point.position) < 1.2f)
            {

                if (thorns != null)
                    thorns.ActivScript();
                if (WolfPit != null)
                    WolfPit.ActivScript();
                //if (health != null)
                //    health.ActivScript();
                if (DebufSlowMovemetn != null)
                    DebufSlowMovemetn.enabled = true;
                
                transform.position = point.position;
                isActiv = true;
                
               // Destroy(gameObject);
                // Debug.Log("2");
            }
        }

    }
}
