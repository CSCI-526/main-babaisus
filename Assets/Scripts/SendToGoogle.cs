using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SendToGoogle : MonoBehaviour
{
    [SerializeField] private string URL;

    private long _sessionID;
    private int _platMoveTime;
    private int _lastMoveTime;
    private bool _completeLevel;
    private int _levelClearTries;
    private int _noStars;
    private int _currentLevel;
    //WinLoadNext winLoadNext;
    // Start is called before the first frame update
    private void Awake()
    {
        // Assign sessionID to identify playtests
        _sessionID = DateTime.Now.Ticks;
        //winLoadNext = GetComponent<WinLoadNext>();

    }

        public void Send()
    {
        // Assign variables
        _currentLevel = LevelSelectionManager.currentLevel-1;
        _platMoveTime = 0;
        _lastMoveTime = 0;
        _completeLevel = false;
        Debug.Log("trying to access" + (LevelSelectionManager.currentLevel-1));
        _levelClearTries = LevelSelectionManager.mainRestartCounter[LevelSelectionManager.currentLevel-1];
        _noStars = 0;



        Debug.Log("Level Clear Tries: " + _levelClearTries);
        Debug.Log("Current level" + _currentLevel);




        StartCoroutine(Post(_sessionID.ToString(), _platMoveTime.ToString(), _lastMoveTime.ToString(), _completeLevel.ToString(), _levelClearTries.ToString(), _noStars.ToString()));
    }

    private IEnumerator Post(string sessionID, string platMoveTime, string lastMoveTime, string completeLevel, string levelClearTries, string noStars)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.384308309", sessionID);
        form.AddField("entry.1686750853", platMoveTime);
        form.AddField("entry.877042479", lastMoveTime);
        form.AddField("entry.1544985288", completeLevel);
        form.AddField("entry.1822642072", levelClearTries);
        form.AddField("entry.1928645636", noStars);
        

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Form upload complete!");
                }
            }
    }
}
