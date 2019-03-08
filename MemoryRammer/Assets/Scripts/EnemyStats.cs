using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [HideInInspector] public float health;

    public GameObject player;

    int damage;
    // Use this for initialization
    void Start()
    {
        health = 20;
        damage = 2;

        player = GameObject.FindGameObjectWithTag("Player");


        //  health = health * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.y <= -6)
        {
            health = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;


    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
    

}
