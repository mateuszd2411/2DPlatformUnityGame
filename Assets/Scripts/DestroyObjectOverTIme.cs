using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTIme : MonoBehaviour
{
    public float lifeTime;

    private HealthManager theHealth;

    // Start is called before the first frame update
    void Start()
    {
        theHealth = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (theHealth.isDead)
        {
            Destroy(gameObject);
        }*/

        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            Destroy(gameObject);
        }

        

    }
}
