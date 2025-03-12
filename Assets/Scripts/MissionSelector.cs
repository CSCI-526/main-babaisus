using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionSelector : MonoBehaviour
{
    public int missionNumber;
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI starAcquiredText;
    // Start is called before the first frame update
    void Start()
    {
        missionText.text = "Mission " + GetMissionLetter(missionNumber);
    }

    private char GetMissionLetter(int number) {
        if (number >= 1 && number <= 26) {
            return (char)('A' + number - 1);
        }
        return '?'; 
    }

    private void OnEnable() {
        int currentType = LevelSelectionManager.type;
        int starSum = 0;
        int starFull = 0;
        int[] indexes = LevelSelectionManager.getLevelIndexes();
        Debug.Log("Mission: " + missionNumber.ToString());
        for(int i = indexes[missionNumber-1]; i < indexes[missionNumber]; i++){
            starFull += 3;
            starSum += PlayerPrefs.GetInt("stars" + LevelSelectionManager.levelPrefix[currentType] + i.ToString(), 0);
        }
        starAcquiredText.text = $"{starSum} / {starFull}";
    }

    public void onSelectMission() {
        LevelSelectionManager.mission = missionNumber;
        Debug.Log("select mission : " + missionNumber.ToString());
    }
}
