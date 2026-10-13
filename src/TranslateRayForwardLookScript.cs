using UnityEngine;

public class TranslateRayForwardLookScript : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(goal.position);
        this.transform.Translate(speed * Time.deltaTime * Vector3.forward);
        Debug.DrawRay(this.transform.position,this.transform.forward,Color.red);
    }
}
