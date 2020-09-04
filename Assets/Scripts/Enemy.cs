using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private const string MOVE = "Move";
    private const string ATTACK = "Attack";
    private const string STATE_DIE = "Die";
    private const string STATE_ATTACK = "Attack";

    public GameObject Objective; // Player to be followed by the enemy
    public bool IsAttacking;
    public float MinimumDistance;

    private Vector3 initialPosition;
    private NavMeshAgent agent;
    private bool haObstacle;
    private Animator animator;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        this.initialPosition = this.transform.position;
        this.agent = GetComponent<NavMeshAgent>();
        this.animator = GetComponent<Animator>();
        this.isDead = false;
        this.IsAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_ATTACK) && this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            this.IsAttacking = true;
        }
        else
        {
            this.IsAttacking = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_DIE)) {
            this.IsAttacking = false;
            this.isDead = false;
        }
        else if (!isDead)
        {
            NavMeshHit navMeshHit;
            this.haObstacle = NavMesh.Raycast(this.transform.position, this.Objective.transform.position, out navMeshHit, NavMesh.AllAreas);
            Debug.DrawLine(this.transform.position, this.Objective.transform.position, this.haObstacle ? Color.red : Color.green);

            if (!this.haObstacle)
            {
                float distance = Vector3.Distance(this.transform.position, this.Objective.transform.position);
                transform.LookAt(this.Objective.transform);
                this.agent.isStopped = false;
                MoveTo(this.Objective.transform.position);
                this.AttackAnimation(0);
                this.MoveAnimation(1);
                if (distance <= MinimumDistance)
                {
                    this.agent.isStopped = true;
                    this.AttackAnimation(1);
                    //GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                MoveTo(this.initialPosition);
            }
            if (this.haObstacle && this.agent.remainingDistance < 1)
            {
                this.MoveAnimation(0);
                this.AttackAnimation(0);
            }
        }
    }

    void MoveAnimation(int state)
    {
        animator.SetInteger(MOVE, state);
    }

    void AttackAnimation(int state)
    {
        GetComponent<Animator>().SetInteger(ATTACK, state);
    }


    void MoveTo(Vector3 to)
    {
        this.agent.SetDestination(to);
    }
}
