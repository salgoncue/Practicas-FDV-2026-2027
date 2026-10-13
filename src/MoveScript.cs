using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public TranslateRayLookScript translateRayLookScript;
    public float speed = 1.0f;
    public float translateSpeedMax = 3.0f;
    float translateSpeed;
    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        translateSpeed = translateRayLookScript.speed;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            translateRayLookScript.speed = 3.0f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            translateRayLookScript.speed = translateSpeed;
        }
        this.transform.Translate(speed * Time.deltaTime * direction.normalized, Space.World);
    }
}
