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
    {
        if (other.CompareTag("Goal")) 
        {
            Debug.Log("you win!");
            uiLevelManager.OnGameWin();
        }
        else if (other.CompareTag("Poison")) 
        {
            Debug.Log("you die!");
            uiLevelManager.OnGameLose();
        }
        else if (other.CompareTag("Taube"))
        {
            uiLevelManager.AddTaube();
            Destroy(other.gameObject);
        }
    }
    
    
    
}
