using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreControllerScript : MonoBehaviour
{
    [HideInInspector] public Text scoreText;
    [HideInInspector] public Text timeText;
    private GameObject player;
    private float startTime;
    [HideInInspector] public float time;
    [HideInInspector] public float lapsedTime;
    [HideInInspector] public GameObject gameController;
    public GameObject canvas;
    

   [HideInInspector] public float timeToClompleteLevel;

    void Awake()
    {
        timeToClompleteLevel = 135f;
        canvas.gameObject.SetActive(true);

        player = GameObject.Find("Player");
        gameController = GameObject.Find("GameController");
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); ;
        timeText = GameObject.Find("TimeText").GetComponent<Text>(); ;
        scoreText.text = "";


        startTime = timeToClompleteLevel;
        // startTime += timeToClompleteLevel;


    }

    // Update is called once per frame
    void Update()
    {
        lapsedTime = Time.timeSinceLevelLoad;


        if (Time.timeSinceLevelLoad > timeToClompleteLevel)
        {

            player.GetComponent<PlayerStats>().TakeDamage(2);
            timeText.text = "Time: 0:0.00";


        }

        if (startTime > 0.0f && Time.timeSinceLevelLoad < timeToClompleteLevel && gameController.GetComponent<GameControllerScript>().youWon == false && gameController.GetComponent<GameControllerScript>().gameIsOver == false)
        {

            time = Time.timeSinceLevelLoad - startTime;
            time *= -1;
            string minutes = ((int)time / 60).ToString();
            string seconds = (time % 60).ToString("f2");

            timeText.text = "Time: " + minutes + ":" + seconds;

        }

        if (time < 10f)
        {
            timeText.color = new Color(1f, 0f, 0f, 1f);

        }
    }
    public IEnumerator ShinyTextTime(float vaule)
    {
        for (int i = 0; i < 5; i++)
        {
            timeText.color = new Color(1f, 1f, 0f, 1f);
            yield return new WaitForSeconds(vaule);
            timeText.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(vaule);

        }

    }



    public void IncTime(float vaule)
    {
        // time += vaule;
        //faz nada acima

        startTime += vaule;
        StartCoroutine(ShinyTextTime(0.1f));
    }
}
