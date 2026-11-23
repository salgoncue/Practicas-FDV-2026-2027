using Unity.Cinemachine;
using UnityEngine;

public class SwapCameras : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
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
