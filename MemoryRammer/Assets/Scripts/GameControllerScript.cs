using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public GameObject player;

    public AudioSource musicGame;
    public GameObject gameOverSound;

    public bool gameIsOver;
    public bool youWon;
    public Image blackBGImage;
    public Animator blackBGImageAnimator;
    public Image wonImage;
    public Animator wonImageAnimator;
    public Animator buttonsAnimator;

    public float cursorMovementX;
    public float cursorMovementY;
    public float time;


    // public GameObject scoreController;
    Scene currentScene;


    private int once;
    // Use this for initialization
    void Start()
    {



        //  scoreController = GameObject.Find("ScoreController");

        youWon = false;
        once = 0;

        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        //  time = Time.timeSinceLevelLoad;
        // Debug.Log(time);

        cursorMovementX = Mathf.Abs(Input.GetAxis("Mouse X"));
        cursorMovementY = Mathf.Abs(Input.GetAxis("Mouse Y"));


        //  if (cursorMovementX <= 0.001f || cursorMovementY <= 0.001f)

        //  {
        // Cursor.visible = false;

        //  }
        //  else

        //   {
        //  Cursor.visible = true;


        //   }



        if (youWon)
        {

            wonImage.gameObject.SetActive(true);

            wonImageAnimator.SetTrigger("YouWin");


        }
        else
        {
            wonImage.gameObject.SetActive(false);


        }


        if (player.GetComponent<PlayerStats>().health <= 0)
        {
            gameIsOver = true;


            StartCoroutine(FadeGAmeOver());

        }
        else
        {

            gameIsOver = false;
            Time.timeScale = 1;

        }




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<PlayerStats>().health = 0;


        }

        if (gameIsOver && !youWon)
        {

            blackBGImageAnimator.SetTrigger("GameIsOver");
            buttonsAnimator.SetTrigger("GameIsOver");



        }
        else
        {

            //blackBGImage.gameObject.SetActive(false);
            //gameOverSound.Stop();
            // musicGame.Play();



        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(currentScene.name);

    }

    public void Continue()
    {
        SceneManager.LoadScene("LevelMenuScene");

    }

    IEnumerator FadeGAmeOver()
    {

        if (!youWon)
        {
            musicGame.volume = 0;
            if (once == 0)
            {
                Instantiate(gameOverSound, transform.position, Quaternion.identity);
                once = 1;
            }



            yield return new WaitForSeconds(2);
            Time.timeScale = 0;
        }


    }


}
