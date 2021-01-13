using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //Loading screen 


public class PauseMenu : MonoBehaviour
{
    public GameObject optionsScreen, pauseScreen; //refers to the method OpenOptions
    // Start is called before the first frame update
    public string mainMenuScene;
    private bool isPaused;
    public GameObject loadingScreen, loadingIcon; //Loading screen
    public Text loadingText; //Loading screen
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }
    public void PauseUnpause()
    {
        if (!isPaused)
        {
            pauseScreen.SetActive(true);
            isPaused = true;
            Time.timeScale = 0f;
        } else
        {
            pauseScreen.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }
    public void QuitMenu()
    {
        //SceneManager.LoadScene(mainMenuScene);
        // Time.timeScale = 1; //because we included it in public Ienumerable LoadMain()
         StartCoroutine(LoadMain());



    }

 

    public IEnumerator LoadMain() //this starts a coroutine
    {
        loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainMenuScene);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.text = "Press any key to continue";
                loadingIcon.SetActive(false);
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                    Time.timeScale = 1f;
                }
            }
            yield return null;

        }
        
    }

}
