using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


    [HideInInspector] public int health;
    public Animator playerAnimation;

    public GameObject gameController;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        health = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <=-6)
        {
            health = 0;
        }

        if (health <= 0)
        {
            playerAnimation.Play("Rammer_Dying");

        }
    }

    public void TakeDamage(int damage)
    {
        if (gameController.gameObject.GetComponent<GameControllerScript>().youWon == false || gameController.gameObject.GetComponent<GameControllerScript>().gameIsOver == false)
        {
            health -= damage;


        }


    }

}
