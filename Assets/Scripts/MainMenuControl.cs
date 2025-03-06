using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject title;
    // type = 0, play 
    public GameObject levelPanel;
    public GameObject missionPanel;
    public GameObject panelForPlay;

    // type = 1, tutorial
    public GameObject tutorialPanel;
    public GameObject tutorialMissionPanel;
    public GameObject panelForTutorial;
    // // Start is called before the first frame update
    void Start()
    {
        if(LevelSelectionManager.ShowLevelSelector) {
            if(LevelSelectionManager.type == 0) {
                // back to play panel
                levelPanel.SetActive(true);
                missionPanel.SetActive(false);
                panelForPlay.SetActive(true);
            } else {
                // back to tutorial panel
                tutorialPanel.SetActive(true);
                tutorialMissionPanel.SetActive(false);
                panelForTutorial.SetActive(true);
            }
            
            menuButton.SetActive(false);
            title.SetActive(false);
            LevelSelectionManager.ShowLevelSelector = false;
        }
    }

    public void StartGame() {
        // load mission scene
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void onClickTutorialButton() {
        LevelSelectionManager.type = 1;
    }

    public void onClickPlayButton() {
        LevelSelectionManager.type = 0;
    }
}
