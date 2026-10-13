using System;
using UnityEngine;

public class TranslateRayForwardLookJitteringScript : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;
    public float accuracy = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position - goal.position).magnitude > accuracy) {
            this.transform.LookAt(goal.position);
            this.transform.Translate(speed * Time.deltaTime * Vector3.forward);
            Debug.DrawRay(this.transform.position,this.transform.forward,Color.red);
        }
    }
}
