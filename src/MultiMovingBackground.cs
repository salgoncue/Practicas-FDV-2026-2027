using UnityEngine;

public class MultiMovingBackground : MonoBehaviour
{
    [SerializeField] GameObject[] leftQuad;
    [SerializeField] GameObject[] rightQuad;
    [SerializeField] float scrollSpeed = 0.005f;
    GameObject[] actualQuad;
    GameObject[] auxiliarQuad;
    float cameraWidth;
    float previousX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualQuad = new GameObject[leftQuad.Length];
        for (int i = 0; i < leftQuad.Length; ++ i)
        {
            actualQuad[i] = leftQuad[i];
        }
        auxiliarQuad = new GameObject[rightQuad.Length];
        for (int i = 0; i < rightQuad.Length; ++ i)
        {
            auxiliarQuad[i] = rightQuad[i];
        }
        cameraWidth = 320f / 180f * 2 * GetComponent<Camera>().orthographicSize;
        previousX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < actualQuad.Length; ++i)
        {
            if (Mathf.Abs(transform.position.x - previousX) > 0.1f) {
                Vector2 direction = new(3 * i * scrollSpeed * Time.deltaTime * -Mathf.Sign(transform.position.x - previousX), 0);
                actualQuad[i].transform.Translate(direction);
                auxiliarQuad[i].transform.Translate(direction);
            }
            if (actualQuad[i].transform.position.x + actualQuad[i].GetComponent<SpriteRenderer>().size.x < transform.position.x)
            {
                actualQuad[i].transform.position = new(auxiliarQuad[i].transform.position.x + actualQuad[i].GetComponent<SpriteRenderer>().size.x, 0, 0);
                if (actualQuad[i] == leftQuad[i])
                {
                    actualQuad[i] = rightQuad[i];
                    auxiliarQuad[i] = leftQuad[i];
                }
                else
                {
                    actualQuad[i] = leftQuad[i];
                    auxiliarQuad[i] = rightQuad[i];
                }
            }
        }
        previousX = transform.position.x;
    }
}
