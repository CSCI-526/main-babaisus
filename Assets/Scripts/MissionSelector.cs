using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionSelector : MonoBehaviour
{
    public int missionNumber;
    public TextMeshProUGUI missionText;
    // Start is called before the first frame update
    void Start()
    {
        missionText.text = "Mission " + missionNumber.ToString();
    }

    public void onSelectMission() {
        LevelSelectionManager.mission = missionNumber;
        Debug.Log("select mission : " + missionNumber.ToString());
    }
}
