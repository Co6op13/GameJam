using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offsenMovement = 1f;
    private Path path;


    private int indexWayPoint = 0;

    private void Start()
    {

        path = FindObjectOfType<Path>();
        Debug.Log(path.WayPoints[0].position);
    }

    private void FixedUpdate()
    {
        Movement();
        CheckDistanceToWaypoint();

        
            
    }

    void Movement ()
    {
        float offset = Random.Range(-offsenMovement, offsenMovement);
        Vector2 destination = new Vector3(path.WayPoints[indexWayPoint].position.x + offset,
                                            path.WayPoints[indexWayPoint].position.y + offset,
                                            path.WayPoints[indexWayPoint].position.z);

        transform.position = Vector2.MoveTowards(transform.position,destination, speed * Time.deltaTime);
    }

    void CheckDistanceToWaypoint()
    {
        if (Vector2.Distance(transform.position, path.WayPoints[indexWayPoint].position) < 0.1f)
        {
            Debug.Log(path.WayPoints.Length + " " + indexWayPoint);
            if (path.WayPoints.Length - 1 > indexWayPoint)
            indexWayPoint++;

        }
    }

}
