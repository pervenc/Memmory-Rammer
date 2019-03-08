using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [HideInInspector] public Vector2 target1;
    [HideInInspector] public Vector2 target2;
    [HideInInspector] public Vector2 targetToGo;

    [HideInInspector] public float playerRunSpeed;


   public GameObject player;
    float speed;
    public float patrolRadiusRange;

    float inicialPos;

    public float pace;


    public bool inveseDirection;





    private void Awake()
    {

      //  player = GameObject.Find("Player");

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

        /*
        if (player.transform.position.x >= 85)
        {
            this.enabled = true;
            GetComponent<PlatformMovement>().enabled = true;
        }


        if (gameObject.tag == ("Floater"))
        {
            {

            }

        }
        */

    }

    void FixedUpdate()
    {

        speed = pace * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetToGo.x, transform.position.y), speed);


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
