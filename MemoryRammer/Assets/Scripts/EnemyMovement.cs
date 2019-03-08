using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    float speed;
    float startSpeed;
    float searchRadius;
    Transform player;
    //   GameObject monster;
    bool onSearchRadius;
    float seePlayerBoostMove;
    bool playerGrounded;
    public Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        ///ENEMIES BELOW///

        if (this.gameObject.tag == "Bugger")
        {
            startSpeed = 1.6f;
            searchRadius = 3.3f;
            //   monster = GameObject.FindGameObjectWithTag("Bugger");
        }

        ///ENEMIES ABOVE///

    }
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) < searchRadius  && !(playerGrounded && player.position.y - transform.position.y > 1.5f) && !(player.position.y - transform.position.y > 0.8f && playerGrounded))
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);

        }
    }

    void Update()
    {

        if (player.GetComponent<PlayerStats>().health <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            rb.simulated = false;
        }

        playerGrounded = player.GetComponent<PlayerMovement>().grounded;
        if (Vector2.Distance(transform.position, player.position) < searchRadius  && !(playerGrounded && player.position.y - transform.position.y > 1.5f) && !(player.position.y - transform.position.y > 0.8f && playerGrounded))
        {

            onSearchRadius = true;

        }
        else
        {
            onSearchRadius = false;

        }


        if (onSearchRadius)
        {
            seePlayerBoostMove = Random.Range(1.1f, 1.25f);

            speed = startSpeed * seePlayerBoostMove;

            if (player.position.x - transform.position.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
        }
        else
        {
            // if (portal.position.x - transform.position.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            // else
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
        }






        //Debug.Log(speed);

    }

}
