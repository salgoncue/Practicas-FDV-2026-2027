using UnityEngine;

public class TranslateScript : MonoBehaviour
{
    public Vector3 goal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.Translate(goal);
        goal = goal * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(goal);
        goal = goal * 2.0f;
    }
}
