using UnityEngine;

public class WaypointTraveler : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1.0f;
    public float rotationSpeed = 1.0f;
    public float accuracy = 0.01f;
    int actualWaypoint = 0;
    Transform goal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goal = waypoints[actualWaypoint];
        if ((this.transform.position - goal.position).magnitude > accuracy) {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(goal.transform.position - transform.position, Vector3.up),
                Time.deltaTime * rotationSpeed);
            this.transform.Translate(speed * Time.deltaTime * Vector3.forward);
        } else
        {
            if (++actualWaypoint >= waypoints.Length)
            {
                actualWaypoint = 0;
            }
        }
    }
}
