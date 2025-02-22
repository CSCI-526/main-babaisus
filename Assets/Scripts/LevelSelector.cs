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
        actualLevel = (LevelSelectionManager.mission - 1) * 3 + levelInMission;
        levelText.text = actualLevel.ToString();
        int starCount = PlayerPrefs.GetInt("stars" + LevelSelectionManager.type + actualLevel.ToString(), 0);
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

    public void OpenLevelScene() {
        Debug.Log("click");
        // var type = ToggleSwitch.CurrentValue ? "WackyLevel" : "NEW Level ";
        LevelSelectionManager.currentLevel = actualLevel;
        Debug.Log("current select: " + LevelSelectionManager.currentLevel);
        SceneManager.LoadScene(LevelSelectionManager.type + actualLevel.ToString());
    }
}
