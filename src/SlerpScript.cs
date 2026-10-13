using UnityEngine;

public class SlerpScript : MonoBehaviour
{
    public Transform goal;
    public float speed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(goal.transform.position - transform.position, Vector3.up), Time.deltaTime * speed);
    }
}
