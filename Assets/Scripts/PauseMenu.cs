using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused;
    public GameObject pauseMenuUI;

    private void Start() {
        gameIsPaused = false;
    }


    public void PauseGame(){
        gameIsPaused = !gameIsPaused;
        if(gameIsPaused){
            Time.timeScale = 0;
            AudioListener.pause = true;
            pauseMenuUI.SetActive(true);
        }
        else{
            ResumeGame();
        } 
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
    }
}
