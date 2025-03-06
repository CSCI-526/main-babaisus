using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static int restartCounter = 0;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // freeze game
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToHome(int sceneID) {
        Time.timeScale = 1f;
        LevelSelectionManager.currentLevel += 1;// for restart counter

        LevelSelectionManager.mainRestartCounter[LevelSelectionManager.currentLevel-1]=PauseMenu.restartCounter;
        PauseMenu.restartCounter=0;
        
        LevelSelectionManager.ShowLevelSelector = true; 
        SceneManager.LoadScene(sceneID);
    }

    public void RestartGame() {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restartCounter++;
        Debug.Log("Restart Counter: " + restartCounter);
        
    }
}
