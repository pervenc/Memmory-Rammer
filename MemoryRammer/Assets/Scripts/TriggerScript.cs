using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    Collider2D boxCollider;
    Vector2 target;
   public bool triggered = false;
    // Use this for initialization
    void Start()
    {
        target = new Vector2(transform.position.x, transform.position.y - 0.0625f);

        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (triggered)
        {
            float step = 0.2f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {/*
        if (other.gameObject.CompareTag("GroundChecker"))
        {
            boxCollider.enabled = false;

            if (gameObject.name == "Trigger1")
            {
                spikeAnim.Play("SpikeShoot1");
                triggerAnim.Play("TriggerDown1");
            }
            else if (gameObject.name == "Trigger2")
            {
                spikeAnim.Play("SpikeShoot2");
                triggerAnim.Play("TriggerDown2");

            }
            else if (gameObject.name == "Trigger3")

            {

                spikeAnim.Play("SpikeShoot3");
                triggerAnim.Play("TriggerDown3");
            }
            else
            {
                spikeAnim.Play("SpikeShoot4");
                triggerAnim.Play("TriggerDown4");
            }

        }*/

        boxCollider.enabled = false;

        triggered = true;


    }

}
