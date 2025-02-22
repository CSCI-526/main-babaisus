using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionName : MonoBehaviour
{
    public TextMeshProUGUI missionName;
    // Start is called before the first frame update
    public void OnEnable() {
        missionName.text = LevelSelectionManager.missionNames[LevelSelectionManager.mission - 1];
    }
}
