using UnityEngine;

public class Offset : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.005f;
    Material[] materials;
    Vector2 offset = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materials = GetComponent<MeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
        // offset.x = scrollSpeed * transform.position.x; Without Parallax
        for (int i = 0; i < materials.Length; ++i) {
            offset.x = scrollSpeed * transform.position.x / (materials.Length - i + 1.0f); // With Parallax
            materials[i].SetTextureOffset("_BaseMap", offset);
        }
    }
}
