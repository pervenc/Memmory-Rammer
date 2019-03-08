using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitWallScript : MonoBehaviour
{

    public GameObject player;

    public GameObject gameController;

    public Scene currentScene;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        currentScene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.GetComponent<GameControllerScript>().youWon = true;

            player.GetComponent<PlayerMovement>().playerAnimation.Play("Rammer_Dying");
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            player.GetComponent<PolygonCollider2D>().enabled = false;

            for (int i = 0; i < 9; i++)
            {
                if (currentScene.name == ("Level_0") + i)
                {
                    if (PlayerPrefs.GetInt("MaxLevelYouCanGo") < i + 1)
                    {
                        PlayerPrefs.SetInt("MaxLevelYouCanGo", i + 1);

                    }
                }
            }

        }
    }


}
