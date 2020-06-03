using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] int levelIndex = 0;
    [SerializeField] float timeLeft = 30f;
    [SerializeField] float addTime = 3f;
    [SerializeField] float reduceTime = 2f;
    [SerializeField] AudioClip timeIsUpSFX;

    //[Header("Set UI for win/lose")]
    //[SerializeField] GameObject winLabel;
    //[SerializeField] GameObject loseLabel;
    //public Text timerLeftText;
    
    private int pickUps;
    public bool startCount = false;
    private bool isBossDestroyed;

    public static Level Instance;

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

        startCount = false;
        //---Get the number of pickups in the scenario
        //pickUps = GameObject.FindGameObjectsWithTag("Pickups").Length;

        //---UI inactive when the game begins
        //winLabel.SetActive(false);
        //loseLabel.SetActive(false);
        GuiManager.SetSplashScreen(levelIndex);
        GuiManager.SetPanel(GuiPanel.Info);
        Time.timeScale = 0;


    }

    public void RegisterPickup(Pickup pickupInstance)
    {
        pickUps++;
    }

    // Update is called once per frame
    void Update()
    {
        //---if the button in the panel has been pressed, the timer starts
        if (startCount)
        {   
          RemainingPickups();
          TimeLeftInLevel();
        }
        
    }

    //---Sets the timer in the game
    private void TimeLeftInLevel()
    {
        if(timeLeft >= 0 && startCount == true)
        {
            timeLeft -= Time.deltaTime;
            //AddTimeToLevel();
            //---display time in the UI
            //timerLeftText.text = (timeLeft).ToString("0");
            GuiManager.SetTimeText((timeLeft).ToString("0"));

            if (timeLeft <= 0)
            {

                //startCount = false
                AudioSource.PlayClipAtPoint(timeIsUpSFX, Camera.main.transform.position);
                ShowGameOver();
                //Debug.Log("Game over!");

            }
        }
        
           
    }

    //---When the pickups are collected, the player receives additional time
    public void AddTimeToLevel()
    {
        timeLeft += addTime;
        pickUps--;
    }

    public void ReduceTimeToLevel()
    {
        timeLeft -= reduceTime;
    }

    //---checks how many pickups remain in scene, since the player is collecting them
    public int RemainingPickups()
    {
        print(pickUps);
        return pickUps;
    }

    //---When pressing the OK button in panel, the timer begins
    //---sets the boolean from false to true
    public void StartCount()
    {
        startCount = true;
        GuiManager.SetPanel(GuiPanel.Time);
        Time.timeScale = 1;
    }


    //---Shows game over panel
    public void ShowGameOver()
    {
        //Time.timeScale = 0;
        startCount = false;
        //loseLabel.SetActive(true);
        GuiManager.SetPanel(GuiPanel.GameOver);
    }

    //---Helps to set the value so we can proceed to next Scene
    public bool BossDestroyed()
    {
        return isBossDestroyed = true;
    }

}
