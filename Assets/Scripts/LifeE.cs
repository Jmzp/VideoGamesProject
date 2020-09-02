using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeE : MonoBehaviour
{
    //public GameObject GameOverImage;
    public int MaxHits;
    // Start is called before the first frame update
    void Start()
    {
        MaxHits = this.MaxHits;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PolyartSword" && this.MaxHits <= 5)
        {
            this.MaxHits -= 1;
            print("prueba");
        }
        if (this.MaxHits == 0)
        {
            Destroy(this.gameObject);
            print("Muerto");
        }
            //this.GameOverImage.SetActive(true);
           //Destroy(other.transform.gameObject);
    }
}
