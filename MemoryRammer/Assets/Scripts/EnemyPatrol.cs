using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [HideInInspector] public Vector2 target1;
    [HideInInspector] public Vector2 target2;
    [HideInInspector] public Vector2 targetToGo;

    [HideInInspector] public float playerRunSpeed;


    float speed;
    public float patrolRadiusRange;

    float inicialPos;

    public float pace;


    public bool inveseDirection;

    [HideInInspector] public bool onAPlatform;


    private GameObject platformYouAreOn;


    private void Awake()
    {


        inicialPos = transform.position.x;

    }

    void Start()
    {
        target1 = new Vector2(transform.position.x - patrolRadiusRange, transform.position.y);
        target2 = new Vector2(transform.position.x + patrolRadiusRange, transform.position.y);

        if (inveseDirection)
        {
            targetToGo = target2;

        }
        else
        {
            targetToGo = target1;

        }


    }

    void Update()
    {



        if (gameObject.tag == ("Floater"))
        {
            {

            }

        }


    }

    void FixedUpdate()
    {

        speed = pace * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetToGo.x, transform.position.y), speed);
        if (onAPlatform)
        {
            if (platformYouAreOn.gameObject.GetComponent<PlatformMovement>().enabled)
            {
                if (platformYouAreOn.gameObject.GetComponent<PlatformMovement>().targetToGo == platformYouAreOn.gameObject.GetComponent<PlatformMovement>().target1)
                {

                    targetToGo = platformYouAreOn.gameObject.GetComponent<PlatformMovement>().targetToGo + new Vector2(-10, 0);

                    //   targetToGo.x -= 10;

                }
                else
                {
                    targetToGo = platformYouAreOn.gameObject.GetComponent<PlatformMovement>().targetToGo + new Vector2(10, 0);

                    //   targetToGo.x += 6;

                }
            }




        }
        else
        {
            if (transform.position.x == inicialPos - patrolRadiusRange)
            {

                targetToGo = target2;



            }
            else if (transform.position.x == inicialPos + patrolRadiusRange)

            {
                targetToGo = target1;


            }

        }




    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ("Floater"))
        {
            onAPlatform = true;
            platformYouAreOn = other.gameObject;

        }
        else if (other.gameObject.tag == ("Ground"))
        {
            onAPlatform = false;
        }


    }



}
