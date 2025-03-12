using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{

    public Image fillImage;

    // Start is called before the first frame update
    public float timeLimit;
    public GameObject leftStar;
    void Start()
    {
        timeLimit=leftStar.GetComponent<StarText>().cutoff;
        Debug.Log(timeLimit);
        
    }

    // Update is called once per frame
    void Update()
    {
        fillImage.fillAmount = 1-(TimerScript.timeElapsed / timeLimit);
        
    }
}
