using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public TextMeshProUGUI mainRequiredText;
    public TextMeshProUGUI expertRequiredText;

    public GameObject mainLock;
    public GameObject expertLock;

    public Button mainMissionButton;
    public Button expertMissionButton;
    public static int[] tutorialStars = {0, 0, 0, 0};
    public static int[] mainStars = new int [30]; // longer than the actual number of main levels
    public static int[] expertStars = new int [15];

    private int totalStars = 0;
    // Start is called before the first frame update
    private void Start() {
        getTutorialLevelStars();
        getMainLevelStars();
        CalculateTotalStars();
    }

    public static void getTutorialLevelStars() {
        for(int i = 1; i < 5; i++){
            tutorialStars[i-1] = PlayerPrefs.GetInt("stars" + LevelSelectionManager.levelPrefix[1] + i.ToString(), 0);
        }
    }

    private void getMainLevelStars() {
        for(int i = 1; i < 22; i++){
            mainStars[i-1] = PlayerPrefs.GetInt("stars" + LevelSelectionManager.levelPrefix[0] + i.ToString(), 0);
        }
    }

    private void CalculateTotalStars() {
        totalStars = tutorialStars.Sum();
        if(totalStars < 10) {
            Debug.Log("less than 10");
            mainLock.SetActive(true);
            expertLock.SetActive(true);
            mainRequiredText.text = $"{totalStars} / 10";
            expertRequiredText.text = $"{totalStars} / 30";
            mainMissionButton.interactable = false;
            expertMissionButton.interactable = false;
            return ;
        }
        mainLock.SetActive(false);
        mainMissionButton.interactable = true;
        totalStars += mainStars.Sum();
        if(totalStars < 30) {
            expertLock.SetActive(true);
            expertRequiredText.text = $"{totalStars} / 30";
            expertMissionButton.interactable = false;
            return ;
        }
        expertLock.SetActive(false);
        expertMissionButton.interactable = true;
        
    }
}
