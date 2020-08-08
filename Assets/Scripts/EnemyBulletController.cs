using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float speed;

    public PlayerController player;

    private HealthManager theHealth;

    //public GameObject enemyDeathEffect;

    public GameObject impactEffect;

    //public int pointsForKill;

    public float rotationSpeed;

    public int damageToGive;

    // Start is called before the first frame update
    void Start()
    {
        theHealth = FindObjectOfType<HealthManager>();

        player = FindObjectOfType<PlayerController>();

            if (player.transform.position.x < transform.position.x)
            {
                speed = -speed;
                rotationSpeed = -rotationSpeed;
            }

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            //Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
            //add points for kill enemy
            //ScoreManager.AddPoints(pointsForKill);

            HealthManager.HurtPlayer(damageToGive);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
