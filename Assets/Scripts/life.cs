using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    float health;
    public GameObject LifeBarImage;
    public GameObject GameOverImage;
    public ParticleSystem HealthParticle;
    public ParticleSystem BlodParticle;
    public bool IsDead;
    void Start()
    {
        this.health = 1f;
        this.IsDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Health Item") && this.health <= 0.80f)
        {
            this.health += 0.1035f;
            ShowHealthParticle();
            Destroy(other.transform.gameObject);
        }
        if (other.name.Contains("Enemy")) 
        {
            bool isAttacking = other.gameObject.GetComponent<Enemy>().IsAttacking;
            if (isAttacking)
            {
                ShowBlodParticle();
                this.health -= 0.1035f;
            }
            
        }
        if (this.health <= 0)
        {
            this.IsDead = true;
            this.GameOverImage.SetActive(true);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        this.LifeBarImage.GetComponent<Image>().fillAmount = this.health;
    }

    private void ShowHealthParticle()
    {
        StartCoroutine(StartAndStopParticleSystem(this.HealthParticle));
    }

    private void ShowBlodParticle()
    {
        StartCoroutine(StartAndStopParticleSystem(this.BlodParticle));
    }

    IEnumerator StartAndStopParticleSystem(ParticleSystem particle)
    {
        particle.Play();
        yield return new WaitForSeconds(3);
        particle.Stop();
    }
}
