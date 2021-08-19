using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform[] wayPoints;

    public Transform[] WayPoints { get => wayPoints;  }

    private void Start()
    {
        wayPoints = GetComponentsInChildren<Transform>();

    }
}

