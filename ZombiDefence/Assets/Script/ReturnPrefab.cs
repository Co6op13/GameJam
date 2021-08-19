using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    //[SerializeField] private GameObject placeForConstructions;

    public void OnClick()
    {
        Debug.Log("inst");
        GameObject newObject = Instantiate(prefab);
        FindObjectOfType<GameManager>().CurentCardMinus();
        Destroy(gameObject);
    }


    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector2 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

    //        PlacePrefab(hit);
    //    }
    //}

    //private void PlacePrefab(RaycastHit2D hit)
    //{
    //    if (!EventSystem.current.IsPointerOverGameObject() )
    //    {
    //        GameObject newObject = Instantiate(prefab);
    //        newObject.transform.position = hit.transform.position;

    //    }

        
        
    //}
}
