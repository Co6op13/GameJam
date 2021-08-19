using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float timeToLife = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", timeToLife);

        
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
