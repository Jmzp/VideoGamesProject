using System.Collections;
using TMPro;
using UnityEngine;

public class LifeE : MonoBehaviour
{

    public GameObject SoreTextGameObject;
    public ParticleSystem DeathParticle;
    public int MaxHits;

    private const string DEAD = "Dead";
    private const string STATE_DIE = "Die";

    private Animator animator;
    private bool isShowingParticle;
    private int maxHits;
    private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.maxHits = MaxHits;
        isShowingParticle = false;
        this.enemy = this.gameObject.GetComponent<Enemy>().Objective;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(STATE_DIE) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            if (this.gameObject != null)
            {
                if (!this.isShowingParticle) ShowDeathParticle();
                Destroy(this.gameObject, 1.0f);
            }
        }
    }

    private void OnDestroy()
    {
        if (this.gameObject != null)
        {
            this.SoreTextGameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + IncreaseScore();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PolyartSword" && this.maxHits >= 0)
        {
            bool isAttacking = enemy.GetComponent<Hero>().IsAttacking;
            if (isAttacking)
            {
                Debug.Log(isAttacking);
                this.maxHits -= 1;
            }
        }
        if (this.maxHits == 0)
        {
            DeadAnimation();
        }
    }

    private int IncreaseScore()
    {
        string currentValue = this.SoreTextGameObject.GetComponent<TextMeshProUGUI>().text;
        string [] result = currentValue.Split(' ');
        return int.Parse(result[1]) + MaxHits;
    } 

    private void DeadAnimation()
    {
       this.animator.SetInteger(DEAD, 1);
    }

    private void ShowDeathParticle()
    {
        this.isShowingParticle = true;
        StartCoroutine(StartAndStopParticleSystem(this.DeathParticle));
    }

    IEnumerator StartAndStopParticleSystem(ParticleSystem particle)
    {
        particle.Play();
        yield return new WaitForSeconds(3);
        particle.Stop();
    }
}
