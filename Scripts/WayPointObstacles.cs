using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointObstacles : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed;
    public int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newLoc = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed);
        transform.position = newLoc;

        if (Mathf.Abs(transform.position.x - waypoints[waypointIndex].position.x) < .01f && Mathf.Abs(transform.position.y - waypoints[waypointIndex].position.y) < .01f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }
    }


}
