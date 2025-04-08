using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using JetBrains.Annotations;

public class SendToGoogle : MonoBehaviour
{
    //https://docs.google.com/forms/u/4/d/1B2rWPcdYmn3iYth0e-OOTYbjxUy_TqX3THqMeLikAA4/formResponse
    [SerializeField] private string URL;

    private string _sessionID="";
    private List<Vector2> _platTrajectory;
    private int _lastMoveTime;
    private bool _completeLevel;
    private int _levelClearTries;
    private int _noStars;
    

    private int _currentLevel;
    private List<Vector2> _ballTrajectory;
    public string _gameOutcome;




    //WinLoadNext winLoadNext;
    // Start is called before the first frame update
    private void Awake()
    {
        // Assign sessionID to identify playtests
        _sessionID = Guid.NewGuid().ToString();
        //winLoadNext = GetComponent<WinLoadNext>();

    }

    public static void Outcome(string gameOutcome)
    {
       
       
        LevelSelectionManager.gameOutcomeList.Add(gameOutcome);
        if ((gameOutcome.Contains("Lose") || gameOutcome.Contains("Exit")) || gameOutcome == "Restart")
        {
            LevelSelectionManager.noStarsList.Add(0);
        }
        else{LevelSelectionManager.noStarsList.Add(GameOverManager.starForLevel);}
       
    }

        public void Send()
    {
       // Debug.Log("CALLING SEND");
        // Assign variables
        _currentLevel = (LevelSelectionManager.currentDatalevel)-1;
        _platTrajectory =  PlatControl.GetPositions();
        _lastMoveTime = 0;
        
   
        _levelClearTries = (LevelSelectionManager.mainRestartCounter[LevelSelectionManager.currentDatalevel-1])+1;
       // _noStars = GameOverManager.starForLevel;
        _ballTrajectory = BallMove.GetPositions();
        






        StartCoroutine(Post(_sessionID.ToString(), string.Join(",", _platTrajectory), _lastMoveTime.ToString(), string.Join(',',LevelSelectionManager.gameOutcomeList), _levelClearTries.ToString(), string.Join(',',LevelSelectionManager.noStarsList), _currentLevel.ToString(), string.Join(",", _ballTrajectory)));
        LevelSelectionManager.gameOutcomeList= new List<string>();
        LevelSelectionManager.noStarsList= new List<int>();
    }

    private IEnumerator Post(string sessionID, string platTrajectory, string lastMoveTime, string gameOutcome, string levelClearTries, string noStars, string currentLevel, string ballTrajectory)
    {
        // Create the form and enter responses
        WWWForm form = new WWWForm();
        form.AddField("entry.384308309", sessionID);
        form.AddField("entry.1686750853", platTrajectory);
        form.AddField("entry.1512156387", ballTrajectory);
        form.AddField("entry.877042479", lastMoveTime);
        form.AddField("entry.1544985288", gameOutcome);
        form.AddField("entry.1822642072", levelClearTries);
        form.AddField("entry.1928645636", noStars);
        form.AddField("entry.1116312316", currentLevel);
    

        

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
