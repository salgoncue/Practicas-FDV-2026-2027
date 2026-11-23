using Unity.Cinemachine;
using UnityEngine;

public class CollisionSwapCameras : MonoBehaviour
{
    [SerializeField] CinemachineCamera mainCamera;
    [SerializeField] CinemachineCamera secondaryCamera;
    bool main;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        main = true;
        mainCamera.Priority = 20;
        secondaryCamera.Priority = 10;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Swap();
        }
    }

    public void Swap()
    {
        if (main)
        {
            mainCamera.Priority = 10;
            secondaryCamera.Priority = 20;
        }
        else
        {
            mainCamera.Priority = 20;
            secondaryCamera.Priority = 10;
        }
        main = !main;
    }
}
