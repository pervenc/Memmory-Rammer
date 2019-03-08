using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLuncher : MonoBehaviour
{
    Vector2 target;
    public GameObject trigger;
    float speed;
    // Use this for initialization
    void Start()
    {

        if (transform.localScale.x < 0)
        {
            target = new Vector2(transform.position.x - 11, transform.position.y);

        }
        else
        {
            target = new Vector2(transform.position.x + 11, transform.position.y);

        }
        speed = 1;


    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != target.x)
        {


            if (trigger.GetComponent<TriggerScript>().triggered)
            {

                speed = 5.5f * Time.deltaTime;



                transform.position = Vector2.MoveTowards(transform.position, target, speed);

            }
        }
        else
        {
            Destroy(gameObject);
        }   
    }
}
