using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Platform))]

[RequireComponent(typeof(SpriteRenderer))]
public class BreakingPlatform : MonoBehaviour
{
    Platform platform;
    SpriteRenderer spriteRenderer;
    bool destroying;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platform = GetComponent<Platform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        destroying = false;
    }

    void FixedUpdate()
    {
        if (!destroying && platform.HasPlayer())
        {
            StartCoroutine(DestroyPlatform().GetEnumerator());
            destroying = true;
        }
    }

    IEnumerable DestroyPlatform()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        platform.ForceDettach();
        gameObject.SetActive(false);
    }
}
