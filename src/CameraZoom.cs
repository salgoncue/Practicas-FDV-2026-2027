using Unity.Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineCamera virtualCamera;
    [SerializeField] float speed = 3f;
    readonly float resolution = 16.0f;
    float pixels;
    float size;
    float actualSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pixels = 180f;
        size = pixels / resolution;
        size /= 2;
        actualSize = virtualCamera.Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            pixels = 180f;
            size = pixels / resolution;
            size /= 2;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            pixels = 360f;
            size = pixels / resolution;
            size /= 2;
        }
        if (size < actualSize)
        {
            actualSize -= speed * Time.deltaTime;
            if (actualSize < size)
            {
                actualSize = size;
            }
            virtualCamera.Lens.OrthographicSize = actualSize;
        } else if (size > actualSize)
        {
            actualSize += speed * Time.deltaTime;
            if (actualSize > size)
            {
                actualSize = size;
            }
            virtualCamera.Lens.OrthographicSize = actualSize;
        }
    }

}
