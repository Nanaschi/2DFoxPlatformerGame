using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionScreen;
    public string firstlevel;
    // Start is called before the first frame update
    public GameObject loadingScreen, loadingIcon; //Loading screen
    public Text loadingText; //Loading screen
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        //SceneManager.LoadScene(firstlevel);
        StartCoroutine(LoadStart());
    }
    public void OpenOptions(){
        optionScreen.SetActive (true);
    }
    public void CloseOptions(){
        optionScreen.SetActive(false);
    }
    public void QuitGame(){
        Application.Quit();
        
    }

    public IEnumerator LoadStart() //this starts a coroutine
    {
        loadingScreen.SetActive(true);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(firstlevel);
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
