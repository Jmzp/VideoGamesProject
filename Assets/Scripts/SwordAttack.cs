using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private const string SWORD_ATTACK = "SwordAttack";
    private const string STATE_MELE_ATTACK = "MeleAttack";
    private const string STATE_NORMAL_ATTACK = "NormalAttack";

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetInteger(SWORD_ATTACK, 2);
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetInteger(SWORD_ATTACK, 1);

        }
        if ((animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_MELE_ATTACK) || animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_NORMAL_ATTACK)) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            animator.SetInteger(SWORD_ATTACK, 0);
        }
    }
}
