using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static bool gameIsOver;

    public GameObject gameOverUI;
    public PauseMenu pauseMenuUI;
    

    // Start is called before the first frame update
    void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsOver == true){
            return;
        }

        if(Input.GetKeyDown("e")){
            EndGame();
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseMenuUI.PauseGame();
        }

        if(PlayerStats.Lives <= 0){
            EndGame();
        }
    }

    void EndGame(){
        gameIsOver = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }
}
