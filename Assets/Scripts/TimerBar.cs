using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{

    public Image fillImage;

    // Start is called before the first frame update
    public float timeLimit;
    // public GameObject leftStar;
    public GameObject timer;
    void Start()
    {
        //timeLimit=leftStar.GetComponent<StarText>().cutoff;
        // timeLimit=rightStar.GetComponent<StarText>().cutoff;
        timeLimit=timer.GetComponent<TimerScript>().startCountDown;
        
    }

    // Update is called once per frame
    void Update()
    {
        fillImage.fillAmount = 1-(TimerScript.timeElapsed / timeLimit);
        //fillImage.fillAmount = 1-((TimerScript.startCountDown - TimerScript.countDown) / timeLimit);
        
    }
}
