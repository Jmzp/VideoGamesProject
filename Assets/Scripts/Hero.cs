using Invector.vCharacterController;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private const string SWORD_ATTACK = "SwordAttack";
    private const string STATE_MELE_ATTACK = "MeleAttack";
    private const string STATE_NORMAL_ATTACK = "NormalAttack";
    private const string STATE_DIE = "Die";
    private const string DEAD = "Dead";

    public bool IsAttacking;

    private Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.IsAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Die();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            this.IsAttacking = true;
            this.animator.SetInteger(SWORD_ATTACK, 2);
        }

        if (Input.GetMouseButtonDown(1))
        {
            this.IsAttacking = true;
            this.animator.SetInteger(SWORD_ATTACK, 1);

        }
        if ((this.animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_MELE_ATTACK) || this.animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_NORMAL_ATTACK)) && this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            this.IsAttacking = false;
            this.animator.SetInteger(SWORD_ATTACK, 0);
        }
    }

    private void Die()
    {   
        if (GetComponentInChildren<Life>().IsDead && !this.animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_DIE))
        {
            this.animator.SetBool(DEAD, true);
            GetComponent<vThirdPersonInput>().enabled = false;
        }   
    }
}
