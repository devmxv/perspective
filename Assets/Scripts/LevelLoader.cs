using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;
    public static LevelLoader Instance;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene #: " + currentSceneIndex);
        //print("Scene number: " + currentSceneIndex);
        //---if there is splash screen [0]
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }


    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    //---Start the game
    public void LoadGame()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        //---Advances to next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
