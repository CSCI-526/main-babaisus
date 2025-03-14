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
        // Mission G only has 2 levels rn Mar 14
        // if(currentType == 0 && mission == 7) {
        //     thirdSelector.SetActive(false);
        // } else {
        //     thirdSelector.SetActive(true);
        // }
        thirdSelector.SetActive(true);
    }
}
