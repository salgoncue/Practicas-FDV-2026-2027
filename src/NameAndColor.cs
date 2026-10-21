using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class NameAndColor : MonoBehaviour
{
    private Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        material.color = Random.ColorHSV();
        Debug.Log(collision.gameObject.name);
    }
}
