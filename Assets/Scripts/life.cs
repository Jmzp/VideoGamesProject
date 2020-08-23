using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour
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
        this.health -= 0.205f;
        this.LifeBarImage.GetComponent<Image>().fillAmount = this.health;

        if (this.health <= 0)
            this.GameOverImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
