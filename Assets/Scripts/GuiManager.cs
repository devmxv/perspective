using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GuiPanel
{
    Info, Time, GameOver
}

public class GuiManager : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject timePanel;
    [SerializeField] private GameObject gameOverPanel;

    public static GuiManager Instance;
    private GameObject currentPanel;
    public Text timerLeftText;
    public List<GameObject> SplashScreenPrefab;
    public GameObject SplashScreenContainer;
    




    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    public static void SetPanel(GuiPanel panelType)
    {
        if(Instance.currentPanel != null)
        {
            Instance.currentPanel.SetActive(false);
        }
        switch (panelType)
        {
            case GuiPanel.Info:
                Instance.currentPanel = Instance.infoPanel;
                break;

            case GuiPanel.Time:
                Instance.currentPanel = Instance.timePanel;
                break;

            case GuiPanel.GameOver:
                Instance.currentPanel = Instance.gameOverPanel;
                break;
        }

        if (Instance.currentPanel != null)
        {
            Instance.currentPanel.SetActive(true);
        }
    }

    public static void SetTimeText(string textValue)
    {
        Instance.timerLeftText.text = textValue;
    }

    public static void SetSplashScreen(int levelIndex)
    {
        Instantiate(Instance.SplashScreenPrefab[levelIndex], Instance.SplashScreenContainer.transform);
    }

    public void AcceptLevel()
    {
        Level.Instance.StartCount();
    }

    public void RetryLevel()
    {
        LevelLoader.Instance.RestartScene();
    }




}
