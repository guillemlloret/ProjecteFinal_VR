using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientMovement : MonoBehaviour
{
    private Transform[] waypoints;
    private int currentWaypoint = 0;
    public float speed = 2f;

    public void SetWaypoints(Transform[] points)
    {
        waypoints = points;
        currentWaypoint = 0;
    }

    void Update()
    {
        if (waypoints == null || currentWaypoint >= waypoints.Length) return;

        Transform target = waypoints[currentWaypoint];

        // Movimiento hacia el waypoint
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypoint++;
        }
    }
}
