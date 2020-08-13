using System.Collections;
using UnityEngine;

public class BossWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<BossHealthManager>())
        {
            return;
        }

        Destroy(gameObject);
    }
}
