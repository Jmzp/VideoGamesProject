using UnityEngine;

public class LifeE : MonoBehaviour
{
    private const string DEAD = "Dead";
    public int MaxHits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PolyartSword" && this.MaxHits >= 0)
        {
            this.MaxHits -= 1;
        }
        if (this.MaxHits == 0)
        {
            DeadAnimation();
        }
    }

    private void DeadAnimation()
    {
        GetComponent<Animator>().SetInteger(DEAD, 1);
    }

}
