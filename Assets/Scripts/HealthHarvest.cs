using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHarvest : MonoBehaviour
{
    // Start is called before the first frame update
    int count;
    public GameObject KeyText;
    void Start()
    {
        this.count = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Health Item")
        {
            print(other.name);
            //other.GetComponent<AudioSource>().Play();
            count++;
            //this.KeyText.GetComponent<TextMeshProUGUI>().text = "Keys: " + count;
            Destroy(other.transform.parent.gameObject, 1);
            print(count);

        }
 
    }

    // Update is called once per frame
    void Update()
    {

    }
}