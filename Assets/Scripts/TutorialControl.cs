using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialControl : MonoBehaviour
{
    public Image imageComponent;
    public List<Sprite> sprites; 

    public GameObject mission1Button;
    public GameObject mission2Button;
    public GameObject mission3Button;
    public GameObject mission4Button;

    void OnEnable() {
        int index = LevelSelectionManager.currentDatalevel - 25 - 1;
        if(index >=0 && index < sprites.Count) {
            imageComponent.sprite = sprites[index];
        }
        spawnButton();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D))
        {
            onClickPlayButton();
        }
    }

    private void spawnButton () {
        int currentMission = LevelSelectionManager.currentDatalevel - 25;
        mission1Button.SetActive(currentMission == 1);
        mission2Button.SetActive(currentMission == 2);
        mission3Button.SetActive(currentMission == 3);
        mission4Button.SetActive(currentMission == 4);
    }
    
    public void onClickBackButton () {
        LevelSelectionManager.ShowLevelSelector = true; 
        // main menu scene id: 0
        SceneManager.LoadScene(0);
    }

    public void onClickPlayButton () {
        Debug.Log("Load into level: " + LevelSelectionManager.currentLevel.ToString());
        int currentType = LevelSelectionManager.type;
        SceneManager.LoadScene(LevelSelectionManager.levelPrefix[currentType] + LevelSelectionManager.currentLevel.ToString());
    }
}
