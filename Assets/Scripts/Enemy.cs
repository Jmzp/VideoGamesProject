using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private const string MOVE = "Move";
    private const string ATTACK = "Attack";
    private const string STATE_DIE = "Die";
    public GameObject objective; // Player to be followed by the enemy
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
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_DIE)) {
            this.isDead = true;
            Destroy(this.gameObject, 1.2f);
        }
        else if (!isDead)
        {
            NavMeshHit navMeshHit;
            this.haObstacle = NavMesh.Raycast(this.transform.position, this.objective.transform.position, out navMeshHit, NavMesh.AllAreas);
            Debug.DrawLine(this.transform.position, this.objective.transform.position, this.haObstacle ? Color.red : Color.green);

            if (!this.haObstacle)
            {
                float distance = Vector3.Distance(this.transform.position, this.objective.transform.position);
                transform.LookAt(this.objective.transform);
                this.agent.isStopped = false;
                MoveTo(this.objective.transform.position);
                this.AttackAnimation(0);
                this.MoveAnimation(1);
                if (distance <= 2f)
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
