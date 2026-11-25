using UnityEngine;
[RequireComponent(typeof(Platform))]

[RequireComponent(typeof(SpriteRenderer))]
public class InvisiblePlatform : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Platform platform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        platform = GetComponent<Platform>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spriteRenderer.enabled && platform.HasPlayer())
        {
            spriteRenderer.enabled = true;
        } else if (spriteRenderer.enabled && !platform.HasPlayer())
        {
            spriteRenderer.enabled = false;
        }
    }
}
