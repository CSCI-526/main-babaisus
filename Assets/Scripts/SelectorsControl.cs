using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectorsControl : MonoBehaviour
{
    public GameObject thirdSelector;
    // Start is called before the first frame update
    void OnEnable() {
        int currentType = LevelSelectionManager.type;
        int mission = LevelSelectionManager.mission;
        // rotation only has 2 levels
        // if(currentType == 0 && mission == 2) {
        //     thirdSelector.SetActive(false);
        // } else {
        //     thirdSelector.SetActive(true);
        // }
        // all have 3 levels in Mar 13.
        thirdSelector.SetActive(true);
    }
}
