using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI textMP;
    public GameObject StarRight;
    public GameObject StarMiddle;
    public GameObject StarLeft;
    public GameObject PenaltyRight;
    public GameObject PenaltyMiddle;
    public GameObject PenaltyLeft;
    public static float timeElapsed;
    public bool timerStarted = false;
    public bool timerDone = false;

    public GameObject circle;
    public GameObject circle2;
    // public float circleSpeed = 4.0f;
    private float cutoffRight;
    private float cutoffMiddle;
    private float cutoffLeft;
    private bool penaltyRightGiven = false;
    private bool penaltyMiddleGiven = false;
    private bool penaltyLeftGiven = false;
    private int starCount;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
        starCount = 3;
        cutoffRight = StarRight.GetComponent<StarText>().cutoff; //Variables.Object(StarRight).Get("cutoff");
        cutoffMiddle = StarMiddle.GetComponent<StarText>().cutoff;
        cutoffLeft = StarLeft.GetComponent<StarText>().cutoff;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerDone){
            if (Input.GetKey(KeyCode.Space)){
                timerStarted = true;
                timerDone = true;
                if(circle != null){
                    circle.GetComponent<BallMove>().Begin();
                }
                else if(circle2 != null){
                    circle2.GetComponent<BallMoveWithPlatform>().Begin();
                }
            }
        }

        if (!timerStarted){
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
                Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || 
                Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                timerStarted = true;
            }
        }

        if (timerStarted && !timerDone){
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= cutoffRight && !penaltyRightGiven){
                PenaltyRight.SetActive(true);
                penaltyRightGiven = true;
                starCount -= 1;
            }
            if (timeElapsed >= cutoffMiddle && !penaltyMiddleGiven){
                PenaltyMiddle.SetActive(true);
                starCount -= 1;
                penaltyMiddleGiven = true;
            }
            if (timeElapsed >= cutoffLeft && !penaltyLeftGiven){
                PenaltyLeft.SetActive(true);
                penaltyLeftGiven = true;
                starCount -= 1;
            }
            //if > star, activate cross out
        }

        
        int f = (int)(timeElapsed * 100);
        float floatF = f/100.0f;
        textMP.text = $"Headstart Time: {floatF}";
    }

    public int GetStarCount() {
        return starCount;
    }
}
