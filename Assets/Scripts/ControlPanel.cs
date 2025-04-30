using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public void PauseGame() {
        // pauseMenu.SetActive(true);
        Time.timeScale = 0f; // freeze game
    }

    public void ResumeGame() {
        // pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
