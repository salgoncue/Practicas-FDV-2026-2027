using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GroundManager groundManager;
    public Transform player;
    Transform playerRoot;
    bool hasPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasPlayer = false;
        playerRoot = player.transform.parent;
        groundManager.OnPlatform += AttachPlayer;
        groundManager.OnLeavePlatform += DettachPlayer;
    }

    void AttachPlayer(Transform platform)
    {
        player.transform.SetParent(platform);
        if (platform == transform)
            hasPlayer = true;
    }

    void DettachPlayer(Transform platform)
    {
        player.transform.SetParent(playerRoot);
        if (hasPlayer)
            hasPlayer = false;
    }

    public bool HasPlayer()
    {
        return hasPlayer;
    }

    public void ForceDettach()
    {
        DettachPlayer(transform);
    }

    void Reset()
    {
        groundManager = GameObject.FindWithTag("PlayerGround").GetComponent<GroundManager>();
        player = GameObject.FindWithTag("Player").transform;
    }
}
