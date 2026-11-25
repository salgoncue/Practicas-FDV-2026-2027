using UnityEngine;
[RequireComponent(typeof(Animator))]

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(PlayerAttack))]
public class AnimatorManager : MonoBehaviour
{
    private static readonly int AttackHash = Animator.StringToHash("attack");
    private static readonly int BIsAttackingHash = Animator.StringToHash("bIsAttacking");
    private static readonly int BIsWalkingHash = Animator.StringToHash("bIsWalking");
    Animator animator;
    Movement playerMovement;
    PlayerAttack playerAttack;
    float inputX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
        playerAttack = GetComponent<PlayerAttack>();
        playerAttack.OnAttack += StartAttack;
        playerAttack.OnEndAttack += EndAttack;
    }

    // Update is called once per frame
    void Update()
    {
        inputX = playerMovement.GetInputX();
        if (inputX > -0.2f && inputX < 0.2f)
        {
            animator.SetBool(BIsWalkingHash, false);
        } else
        {
            animator.SetBool(BIsWalkingHash, true);
        }
    }

    void StartAttack()
    {
        animator.SetBool(BIsAttackingHash, true);
        animator.SetTrigger(AttackHash);
    }

    void EndAttack()
    {
        animator.SetBool(BIsAttackingHash, false);
    }
}
