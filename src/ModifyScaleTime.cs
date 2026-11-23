using UnityEngine;

public class ModifyScaleTime : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Slow"))
            {
                Time.timeScale = 0.5f;
            } else if (gameObject.CompareTag("Fast"))
            {
                Time.timeScale = 2f;
            }
        }
    }
}
