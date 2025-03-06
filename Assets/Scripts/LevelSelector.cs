using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    public int levelInMission;
    public TextMeshProUGUI levelText;
    private int actualLevel;

    public GameObject zeroStar;
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;

    private GameObject currentStar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        int currentType = LevelSelectionManager.type;
        int numberOfMission = currentType == 0 ? 3 : 2;
        if(currentType == 0 && LevelSelectionManager.mission >= 3) {
            actualLevel = 5 + (LevelSelectionManager.mission - 3) * numberOfMission + levelInMission;
        } else {
            actualLevel = (LevelSelectionManager.mission - 1) * numberOfMission + levelInMission;
        }
        levelText.text = actualLevel.ToString();
        int starCount = PlayerPrefs.GetInt("stars" + LevelSelectionManager.levelPrefix[currentType] + actualLevel.ToString(), 0);
        // Debug.Log("star count: " + starCount);
        SpawnStar(starCount);
    }

    private void SpawnStar(int starCount)
    {
        zeroStar.SetActive(starCount == 0);
        oneStar.SetActive(starCount == 1);
        twoStar.SetActive(starCount == 2);
        threeStar.SetActive(starCount == 3);
    }

    public void onSelectLevel () {
        LevelSelectionManager.currentLevel = actualLevel;
        Debug.Log("current select: " + LevelSelectionManager.currentLevel);
        PauseMenu.restartCounter = 0;

        if(LevelSelectionManager.type == 1 && levelInMission == 1) {
            // for level 1s for each baby mission
            // show tutorial image -> press button -> play / go back
            SceneManager.LoadScene("TutorialPicScene");
        } else {
            OpenLevelScene();
        }
    }

    public void OpenLevelScene() {
        int currentType = LevelSelectionManager.type;
        // SceneManager.LoadScene(LevelSelectionManager.levelPrefix[currentType] + actualLevel.ToString());
        
        // Maybe it's better to load by SceneId
        int sceneId = 0; // MainMenu scene backup
        if(currentType == 1) {
            // tutorial starts with 2
            sceneId = actualLevel;
        } else {
            // tutorial starts with 9
            sceneId = 8 + actualLevel;
        }
        SceneManager.LoadScene(sceneId);
    }
}
