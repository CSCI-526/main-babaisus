using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static int starForLevel = 0;
    public GameObject gameOverUI;
    public GameObject gamePassUI;
    public GameObject zeroGrid;
    public GameObject oneGrid;
    public GameObject twoGrid;
    public GameObject allGrid;
    public GameObject nextButton;
    public TextMeshProUGUI passText;
    

    public TimerScript timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowGameOver() {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void ShowPassGame() {
        timer = FindObjectOfType<TimerScript>();
        Time.timeScale = 0f;
        gamePassUI.SetActive(true);

        var tutorialCompleted = LevelSelectionManager.type == 1 && LevelSelectionManager.currentLevel == 8;
        var generalCompleted = LevelSelectionManager.type == 0 && LevelSelectionManager.currentLevel == 14;

        if(tutorialCompleted || generalCompleted) {
            nextButton.SetActive(false);
            passText.text = "You Completed!";
        }
        
        starForLevel = timer.GetStarCount();
        SpawnStar(starForLevel);
        Debug.Log("----- star acquired: " + starForLevel.ToString());
        int currentType = LevelSelectionManager.type;
        if(starForLevel > PlayerPrefs.GetInt("stars" + LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString(), 0)) {
            PlayerPrefs.SetInt("stars" + LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString(), starForLevel);
        }
    }

    public void LoadNextLevel() {
        Time.timeScale = 1f;
        LevelSelectionManager.currentLevel += 1;
        LevelSelectionManager.currentDatalevel += 1;
        Debug.Log("next level: " + LevelSelectionManager.currentLevel.ToString());

        LevelSelectionManager.mainRestartCounter[LevelSelectionManager.currentDatalevel-1]=PauseMenu.restartCounter;
        Debug.Log("google restart value: " + LevelSelectionManager.mainRestartCounter[LevelSelectionManager.currentDatalevel-1]);
        PauseMenu.restartCounter=0;

        int currentType = LevelSelectionManager.type;
        int numberOfMission = LevelSelectionManager.type == 0 ? 3 : 2;
        if(currentType == 1) {
            // tutorial
            if(LevelSelectionManager.currentLevel % numberOfMission == 1) {
                LevelSelectionManager.mission += 1;
            }
        } else {
            // general mission
            switch(LevelSelectionManager.currentLevel) {
                case 4:
                case 6:
                case 9:
                case 12:
                    LevelSelectionManager.mission += 1;
                    break;
                default:
                    break;
            }
        }
        if(currentType == 1 && LevelSelectionManager.currentLevel % numberOfMission == 1) {
            // load tutorial graphic for level 1 
            SceneManager.LoadScene("TutorialPicScene");
        } else {
            Debug.Log("======= load next: " + LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString());
            SceneManager.LoadScene(LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString());
        }
        
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SpawnStar(int starCount)
    {
        zeroGrid.SetActive(starCount == 0);
        oneGrid.SetActive(starCount == 1);
        twoGrid.SetActive(starCount == 2);
        allGrid.SetActive(starCount == 3);
    }
}
