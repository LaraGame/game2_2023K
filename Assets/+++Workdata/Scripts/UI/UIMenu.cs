using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] private CanvasGroup panelLevels;
    [SerializeField] private Button buttonLevelselection;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonLevel1;
    [SerializeField] private Button buttonLevel2;
    [SerializeField] private Button buttonLevel3;
    [SerializeField] private Button buttonBack;

    [SerializeField] private string[] levelNames;
    
    void Start()
    {
        panelMain.ShowCanvasGroup();
        panelLevels.HideCanvasGroup();
        
        buttonLevelselection.onClick.AddListener(ShowLevelSelection);
    }

   
    void ShowLevelSelection()
    {
        panelMain.HideCanvasGroup();
        panelLevels.ShowCanvasGroup();
        
    }

    void ShowMainMenu()
    {
        panelLevels.HideCanvasGroup();
        panelMain.ShowCanvasGroup();
    }

    void StartNewGame()
    {
        //loaqd Level1
        SceneManager.LoadScene(levelNames[0]);
    }
    
}
