using UnityEngine;

public class MoveQuads : MonoBehaviour
{
    [SerializeField] GameObject leftQuad;
    [SerializeField] GameObject rightQuad;
    [SerializeField] float scrollSpeed = 2f;
    GameObject actualQuad;
    GameObject auxiliarQuad;
    float cameraWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualQuad = leftQuad;
        auxiliarQuad = rightQuad;
        cameraWidth = 320f / 180f * 2 * GetComponent<Camera>().orthographicSize;
        // CAMERA WIDTH se usará para escalar el fondo en función de la resolución del monitor
        Debug.Log(GetComponent<Camera>().orthographicSize);
        Debug.Log(cameraWidth);
    }

    // Update is called once per frame
    void Update()
    {
        // CÁMARA ESTÁTICA
        // leftQuad.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.left);
        // rightQuad.transform.Translate(scrollSpeed * Time.deltaTime * Vector3.left);
        // if (actualQuad.transform.position.x < -actualQuad.transform.localScale.x)
        // {
        //     actualQuad.transform.position = new(actualQuad.transform.localScale.x, 0, 0);
        //     if (actualQuad == leftQuad)
        //     {
        //         actualQuad = rightQuad;
        //     } else
        //     {
        //         actualQuad = leftQuad;
        //     }
        // }
        
        // CÁMARA EN MOVIMIENTO
        if (actualQuad.transform.position.x + actualQuad.transform.localScale.x < transform.position.x)
        {
            actualQuad.transform.position = new(auxiliarQuad.transform.position.x + actualQuad.transform.localScale.x, 0, 0);
            if (actualQuad == leftQuad)
            {
                actualQuad = rightQuad;
                auxiliarQuad = leftQuad;
            } else
            {
                actualQuad = leftQuad;
                auxiliarQuad = rightQuad;
            }
        }
    }
}
