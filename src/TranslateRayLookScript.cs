using UnityEngine;

public class TranslateRayLookScript : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;
    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(goal.position);
        direction = goal.position - this.transform.position;
        this.transform.Translate(speed * Time.deltaTime * direction.normalized, Space.World);
        Debug.DrawRay(this.transform.position,direction,Color.red);
    }
}
