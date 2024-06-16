using System;
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
    [SerializeField] private Button buttonMain;
    [SerializeField] private Button buttonExit;
    [SerializeField] private string[] levelNames;

    

    void Start()
    {
        panelMain.ShowCanvasGroup();
        panelLevels.HideCanvasGroup();
        
        buttonLevelselection.onClick.AddListener(ShowLevelSelection);
        buttonMain.onClick.AddListener(ShowMainMenu);
        buttonNewGame.onClick.AddListener(LoadLevel1);
        buttonExit.onClick.AddListener(ExitGame);
        
        buttonLevel1.onClick.AddListener(LoadLevel1);
        buttonLevel2.onClick.AddListener(LoadLevel2);
        buttonLevel3.onClick.AddListener(LoadLevel3);

        buttonLevel2.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[1]))
        {
            if (PlayerPrefs.GetInt(levelNames[1]) == 1)
            {
                buttonLevel2.interactable = true;
            }
        }
        
        buttonLevel3.interactable = false;
        if (PlayerPrefs.HasKey(levelNames[2]))
        {
            if (PlayerPrefs.GetInt(levelNames[2]) == 1)
            {
                buttonLevel3.interactable = true;
            }
        }
    }

    void ExitGame()
    {
        Application.Quit();    
    }
    
    
    void ShowLevelSelection()
    {
        Debug.Log("show level");
        
        panelMain.HideCanvasGroup();
        panelLevels.ShowCanvasGroup();
        
    }

    void ShowMainMenu()
    {
        panelLevels.HideCanvasGroup();
        panelMain.ShowCanvasGroup();
    }

    void LoadLevel1()
    {
        //loaqd Level1
        SceneManager.LoadScene(levelNames[0]);
    }
    
    void LoadLevel2()
    {
        //loaqd Level1
        SceneManager.LoadScene(levelNames[1]);
    }
    
    void LoadLevel3()
    {
        //loaqd Level1
        SceneManager.LoadScene(levelNames[2]);
    }
}
