using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offsetSpeed = 1f;
    [SerializeField] private float offsenMovement = 1f;

    private bool isMovement = true;
    private Path path;
    private int indexWayPoint = 1;
    [SerializeField] private float currentSpeed;

    public bool IsMovement { get => isMovement; set => isMovement = value; }

    private void Start()
    {
        
        currentSpeed = speed + Random.Range(-offsetSpeed, offsetSpeed);
        path = FindObjectOfType<Path>();
        //Debug.Log(path.WayPoints[0].position);
    }

    private void FixedUpdate()
    {
        if (isMovement)
            Movement();
        CheckDistanceToWaypoint();       
            
    }

    public void DebafSpeedMovement (float debaf, float timeDebaf)
    {
        Invoke(("NormalizedSpeed"), timeDebaf);
        currentSpeed = speed / debaf;

    }
    public void BafSpeedMovement(float debaf, float timebaf)
    {
        Invoke(("NormalizedSpeed"), timebaf);
        currentSpeed = speed * debaf;

    }

    private void NormalizedSpeed ()
    {
       // IsMovement = true;
        currentSpeed = speed + Random.Range(-offsetSpeed, offsetSpeed);
    }

    void Movement ()
    {
        //float offset = Random.Range(-offsenMovement, offsenMovement);
        Vector2 destination = new Vector3(path.WayPoints[indexWayPoint].position.x + Random.Range(-offsenMovement, offsenMovement),
                                            path.WayPoints[indexWayPoint].position.y + Random.Range(-offsenMovement, offsenMovement),
                                            path.WayPoints[indexWayPoint].position.z);        

        transform.position = Vector2.MoveTowards(transform.position,destination, currentSpeed * Time.deltaTime);
    }

    void CheckDistanceToWaypoint()
    {
        if (Vector2.Distance(transform.position, path.WayPoints[indexWayPoint].position) < 0.2f)
        {
            //Debug.Log(path.WayPoints.Length + " " + indexWayPoint);
            if (path.WayPoints.Length - 1 > indexWayPoint)
            indexWayPoint++;

        }
    }

}
