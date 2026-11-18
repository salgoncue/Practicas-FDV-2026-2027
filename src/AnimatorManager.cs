using UnityEngine;
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(Movement))]
public class AnimatorManager : MonoBehaviour
{
    private static readonly int BIsWalkingHash = Animator.StringToHash("bIsWalking");
    Animator animator;
    Movement playerMovement;

    float inputX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = playerMovement.GetInputX();
        if (inputX > -0.01f && inputX < 0.01f)
        {
            animator.SetBool(BIsWalkingHash, false);
        } else
        {
            animator.SetBool(BIsWalkingHash, true);
        }
    }
}
