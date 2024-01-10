using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadName : MonoBehaviour
{
    public static string playerName = "Govind";

    // Will read the player name entered and store it in static variable that can be used across all the scripts 
    public void readNameInput(string name)
    {
        playerName = name;
    }

    // Starting the game
    public void PlayGame()
    {
        
        SceneManager.LoadScene("Intro Cutscene", LoadSceneMode.Single);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            PlayGame();
        }
    }
}
