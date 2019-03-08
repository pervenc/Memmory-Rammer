using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelControllerScript : MonoBehaviour
{

    public Animator levelAnimation, levelButtonAnimator, cameraAnimator;
    public Scene currentScene;
    public MethodBase methodBase;
    public Text ProgressText;
    public GameObject loadScreen;
    public Slider loadScreenSlider;
    public GameObject levelsSelect;

    public Button[] buttons;
    // public AsyncOperation operation;



    public void Start()
    {

        if (PlayerPrefs.GetInt("MaxLevelYouCanGo") < 1 || PlayerPrefs.GetInt("MaxLevelYouCanGo") > 9)
        {
            PlayerPrefs.SetInt("MaxLevelYouCanGo", 1);
        }

        currentScene = SceneManager.GetActiveScene();
        levelsSelect.SetActive(true);
        Time.timeScale = 1;

        for (int i = 0; i < 8; i++)
        {
            if (i > PlayerPrefs.GetInt("MaxLevelYouCanGo") - 1)
            {
                buttons[i].GetComponent<Image>().color = new Color(0.1882353f, 0.2470588f, 0.2509804f, 1f);

            }
        }

    }

    public void Update()
    {

    }
    public void ResetLevels()
    {
        PlayerPrefs.SetInt("MaxLevelYouCanGo", 1);
        for (int i = 0; i < 8; i++)
        {
            if (i > PlayerPrefs.GetInt("MaxLevelYouCanGo") - 1)
            {
                buttons[i].GetComponent<Image>().color = new Color(0.19f, 0.25f, 0.25f, 1f);

            }
        }

    }

    public void StartOpenLevelCR()
    {

        StartCoroutine(OpenLevel());
    }

    public void LoadAllLevels()
    {

       
        PlayerPrefs.SetInt("MaxLevelYouCanGo", 8);

        for (int i = 0; i < 8; i++)
        {
            if (i < PlayerPrefs.GetInt("MaxLevelYouCanGo") - 1)
            {
                buttons[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

            }
        }


    }
    private IEnumerator OpenLevel()
    {



        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < 9; i++)
        {
            if (buttonName == "Level_0" + i + "_Button")
            {
                // Debug.Log(buttonName);
                if (PlayerPrefs.GetInt("MaxLevelYouCanGo") >= i)
                {
                    levelAnimation.Play("GoToBlackLevel");
                    levelButtonAnimator.Play("LeftButtonMenu");
                    cameraAnimator.Play("CameraLoadScreen");

                    yield return new WaitForSeconds(0.3f);
                    loadScreen.SetActive(true);
                    yield return new WaitForSeconds(0.6f);

                    AsyncOperation operation = SceneManager.LoadSceneAsync("Level_0" + i);

                    while (!operation.isDone)
                    {
                        Debug.Log(operation.progress);

                        float progress = Mathf.Clamp01(operation.progress / 0.9f);
                        loadScreenSlider.value = progress;

                        if (progress < 100)
                        {
                            ProgressText.text = (int)(progress * 100f) + "%";

                        }
                        else
                        {
                            ProgressText.text = " DONE!";

                        }
                        yield return null;

                    }


                }
            }

        }





    }

    public void GoingRightButton()
    {

        levelAnimation.Play("LevelsSelectRightMove");

        //  levelAnimation.SetTrigger("GoingRight");



    }
    public void GoingLeftButton()
    {

        levelAnimation.Play("LevelsSelectLeftMove");

        // levelAnimation.SetTrigger("GoingRight");



    }
}


