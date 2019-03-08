using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinScript : MonoBehaviour
{
    public AudioSource coinSound;
    public GameObject scoreController;


    
    void Update()
    {

    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            coinSound.Play();


            scoreController.gameObject.GetComponent<ScoreControllerScript>().IncTime(2.32f);

            Destroy(gameObject);
        }
    }
   
}
