using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject menuButton;
    public GameObject title;
    public GameObject missionPanel;
    public GameObject panel;
    // // Start is called before the first frame update
    void Start()
    {
        if(LevelSelectionManager.ShowLevelSelector) {
            levelPanel.SetActive(true);
            missionPanel.SetActive(false);
            panel.SetActive(true);
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
}
