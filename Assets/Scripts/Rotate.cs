using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [SerializeField] private WaypointFollower waypoint;

    private void Update()
    {
        if (waypoint.currentWaypointIndex == 0)
        {
            transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -360 * speed * Time.deltaTime);
        }
    }
}
