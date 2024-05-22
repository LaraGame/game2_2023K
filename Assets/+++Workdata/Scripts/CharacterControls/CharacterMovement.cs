using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //private int framecounter = 0;
    private int JumpCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start!");
    }

    // Update is called once per frame
    void Update()
    {
         //framecounter = framecounter + 1;
        //Debug.Log("update...! Framenumber: " + framecounter);
    }

    void OnJump()
    {
        JumpCount = JumpCount + 1;
        Debug.Log("Jump! i jumped " + JumpCount + " times!");
    }
    
}
