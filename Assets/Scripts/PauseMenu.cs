using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static int restartCounter = 0;
    public Image restartTip;
    private bool tipShowed = false;

    void Start() {
        tipShowed = false;
    }
    private void Update() {
        if(!tipShowed && BallMove.ShouldAppearRestart()) {
            tipShowed = true;
            restartTip.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        { 
            SendToGoogle.Outcome("Restart");
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
        LevelSelectionManager.currentDatalevel += 1;

        LevelSelectionManager.mainRestartCounter[LevelSelectionManager.currentDatalevel-1]=PauseMenu.restartCounter;
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
