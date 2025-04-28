using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI nextLevelText;
    

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

        var passTime = timer.GetSpentTime();
        timeText.text = $"Spent {passTime}s before ball dropped";

        var tutorialCompleted = LevelSelectionManager.type == 1 && LevelSelectionManager.currentLevel == 4;
        var mainCompleted = LevelSelectionManager.type == 0 && LevelSelectionManager.currentLevel == 21;
        var expertCompleted = LevelSelectionManager.type == 2 && LevelSelectionManager.currentLevel == 6;
        
        starForLevel = timer.GetStarCount();
        SpawnStar(starForLevel);
        Debug.Log("----- star acquired: " + starForLevel.ToString());
        int currentType = LevelSelectionManager.type;
        if(starForLevel > PlayerPrefs.GetInt("stars" + LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString(), 0)) {
            PlayerPrefs.SetInt("stars" + LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString(), starForLevel);
        }

        if(tutorialCompleted) {
            PlayerData.getTutorialLevelStars();
            var totalStars = PlayerData.tutorialStars.Sum();
            // nextButton.SetActive(false);
            passText.text = "You Completed!";
            nextLevelText.text = "To Mission 1";
            if(totalStars < 10) {
                nextButton.GetComponent<Button>().interactable = false;
            }
        }

        if(mainCompleted || expertCompleted) {
            nextButton.SetActive(false);
            passText.text = "You Completed!";
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
        if(currentType != 1) {
            // main/expert mission
            switch(LevelSelectionManager.currentLevel) {
                case 4:
                case 7:
                case 10:
                case 13:
                case 16:
                case 19:
                    LevelSelectionManager.mission += 1;
                    break;
                default:
                    break;
            }
        }
        if(currentType == 1) {
            // load tutorial graphic for tutorial level
            if(LevelSelectionManager.currentLevel == 5) {
                LevelSelectionManager.type = 0;
                LevelSelectionManager.mission = 1;
                LevelSelectionManager.currentLevel = 1;
                LevelSelectionManager.currentDatalevel = 1;
                Debug.Log("Load Next 4 Current type: " + LevelSelectionManager.type.ToString());
            } 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            Debug.Log("======= load next: " + LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString());
            // SceneManager.LoadScene(LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
