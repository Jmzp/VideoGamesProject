using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    float health;
    public GameObject LifeBarImage;
    public GameObject GameOverImage;
    void Start()
    {
        this.health = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Health Item" && this.health <= 0.80f)
        {
            this.health += 0.1035f;
            Destroy(other.transform.gameObject);
        }
        if (other.name != "Health Item") 
        {
            this.health -= 0.205f;
        }
        if (this.health <= 0)
            this.GameOverImage.SetActive(true);
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
}
