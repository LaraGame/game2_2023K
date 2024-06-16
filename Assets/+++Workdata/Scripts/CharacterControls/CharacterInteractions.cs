using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    private UILevelManager uiLevelManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //sucht nach etwas mit dem namen Uilevelmanager NUR nutzen wenn es nur einmal exixtiert
        uiLevelManager = FindObjectOfType<UILevelManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {  //if player comes in contact with that tag
         
        if (other.CompareTag("Goal")) 
        { // a panel will open
            Debug.Log("you win!");
            uiLevelManager.OnGameWin();
        }
        else if (other.CompareTag("Poison")) 
        { // you will get a debug to see if it works
            Debug.Log("you die!");
            uiLevelManager.OnGameLose();
        } 
        else if (other.CompareTag("Taube"))
        {   // th objects get  destroyed
            uiLevelManager.AddTaube();
            Destroy(other.gameObject);
        }
    }
    
    
    
}
