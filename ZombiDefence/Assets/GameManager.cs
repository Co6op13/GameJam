using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabCard;
    [SerializeField] private int totalCardDeck = 30;
    [SerializeField] private int maxCardInHand = 4;
    [SerializeField] private GameObject text;
    
    [SerializeField] private float timeDelay = 5f;
    [SerializeField] private GameObject hand;

    [SerializeField] private int currentCardInDeck;
    [SerializeField] private int cuurenCardInHand = 0;
    
    private TextMeshProUGUI textCardInDesk;
    private float deltaTimeDelay;
    // Start is called before the first frame update
    void Start()
    {
        textCardInDesk = text.GetComponent<TextMeshProUGUI>();
        Debug.Log(textCardInDesk.name);
        currentCardInDeck = totalCardDeck;
        hand = GameObject.FindGameObjectWithTag("Hand");
        deltaTimeDelay = timeDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hand != null)
        {
            cuurenCardInHand = hand.transform.childCount;
            textCardInDesk.text = currentCardInDeck.ToString();
            
            if (currentCardInDeck > 0)
            if (cuurenCardInHand < maxCardInHand)
            {
                int i = Random.RandomRange(0, prefabCard.Length);
                var o = Instantiate(prefabCard[i]);
                o.transform.parent = hand.transform;
                var temp = o.GetComponent<RectTransform>();
                temp.localScale = new Vector3(1, 1, 1);
                //cuurenCardInHand++;
                currentCardInDeck--;
            }
        }

    }


    public void CurentCardMinus()
    {
        cuurenCardInHand--;
    }
}
