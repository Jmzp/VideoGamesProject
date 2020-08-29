using Invector.vCharacterController;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private const string SWORD_ATTACK = "SwordAttack";
    private const string STATE_MELE_ATTACK = "MeleAttack";
    private const string STATE_NORMAL_ATTACK = "NormalAttack";

    //int count;
    //public GameObject ScoreText;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.name == "Health Item")
    //    {
    //        print(other.name);
    //        //other.GetComponent<AudioSource>().Play();
    //        count++;
    //        //this.ScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + count;
    //        Destroy(other.transform.parent.gameObject, 1);
    //        print(count);

    //    }

    //}

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
