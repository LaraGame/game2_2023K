using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevelManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonPlayAgainWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonBackToMenu1;
    
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonPlayAgainLose;
    [SerializeField] private Button buttonExit;
    [SerializeField] private Button buttonBackToMenu2;
    
    [SerializeField] private string nameNextScene;

    private int taubenCount = 0;
    [SerializeField] private TextMeshProUGUI txtTaubenCount;
    
    
    void Start()
    {
        Time.timeScale = 1f;
        txtTaubenCount.text = taubenCount.ToString();
        //win and lose screen in hiding
        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();
        
        //nutton was soll passieren wenn man rauf clickt dann restaertlevel
        buttonPlayAgainWin.onClick.AddListener(RestartLevel);
        buttonPlayAgainLose.onClick.AddListener(RestartLevel);
        buttonNextLevel.onClick.AddListener(LoadNextLevel);
        buttonExit.onClick.AddListener(ExitGame);
        buttonBackToMenu2.onClick.AddListener(BackToMenu);
        buttonBackToMenu1.onClick.AddListener(BackToMenu);
    }

    public void OnGameWin()
    {
        //show win screen
        panelWin.ShowCanvasGroup();
        PlayerPrefs.SetInt(nameNextScene, 1);
        Time.timeScale = 0f;
    }

    public void OnGameLose()
    {
        //show lose screen
        panelLose.ShowCanvasGroup();
        Time.timeScale = 0f;
    }

    void RestartLevel()
    {
        //reload current Level
        // sm sucht die aktive scene und gibt sie uns zurück buildindex(bei file Build settings das ganz rechts der build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // einfach buildindex nachgucken und eingeben ( so gehts auch)
        // SceneManager.LoadScene(0),
        Time.timeScale = 1f;
    }

    void LoadNextLevel()
    {
        // load the nextx level(scence)
        SceneManager.LoadScene(nameNextScene);
    }

    void ExitGame()
    {
        //exit the game
    }
    
    void BackToMenu()
    {
        // load the nextx level(scence)
        SceneManager.LoadScene("Menu");
    }

    public void AddTaube()
    {
        taubenCount++;
        txtTaubenCount.text = taubenCount.ToString();
        
    }
    
}

public static class UIExtentions
{
    public static void HideCanvasGroup(this CanvasGroup canvasGroup)
    {
        //alpha no showing screen
        //interactable cant interact anymore
        //blockRaycast = klick raycast ksnn nicht irgendwo durch
        
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
    
    public static void ShowCanvasGroup(this CanvasGroup canvasGroup)
    {
        //alpha no showing screen
        //interactable cant interact anymore
        //blockRaycast = klichraycast durchgehen
        
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    
   
}
