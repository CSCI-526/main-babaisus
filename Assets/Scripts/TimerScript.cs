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

    public GameObject starBar;

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
    public bool isTutorialLevel = false;
    public GameObject spaceButton;

    //new, for changing to countdown

    public float startCountDown = 20.0f;
    private float countDown;
     private AudioSource timerAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
        starCount = 3;
        // cutoffRight = StarRight.GetComponent<StarText>().cutoff; //Variables.Object(StarRight).Get("cutoff");
        // cutoffMiddle = StarMiddle.GetComponent<StarText>().cutoff;
        // cutoffLeft = StarLeft.GetComponent<StarText>().cutoff;
        //countDown = cutoffRight;

        countDown = startCountDown;
        cutoffRight = (float) Variables.Object(starBar).Get("mostTime");
        cutoffMiddle = (float) Variables.Object(starBar).Get("mediumTime");
        cutoffLeft = (float) Variables.Object(starBar).Get("leastTime");

        timerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!timerDone){
            if (Input.GetKey(KeyCode.Space)){
                timerStarted = true;
                timerDone = true;
                if(circle != null){
                    circle.GetComponent<BallMove>().Begin();
                }
                else if(circle2 != null){
                    circle2.GetComponent<BallMoveWithStickyPlatformPurple>().Begin();
                }
                if (timerAudio != null && timerAudio.isPlaying)
                    {
                        timerAudio.Stop();
                    }
            }
        }

        if (!timerStarted){
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
                Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || 
                Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                timerStarted = true;

                if (timerAudio != null && !timerAudio.isPlaying)
                    {
                        Debug.Log("Play timer audio");
                        timerAudio.Play();
                    }
            }
        }

        if (timerStarted && !timerDone){
            countDown -= Time.deltaTime;
            timeElapsed += Time.deltaTime;
            // if (timeElapsed >= cutoffRight && !penaltyRightGiven){
            //     PenaltyRight.SetActive(true);
            //     penaltyRightGiven = true;
            //     starCount -= 1;
            // }
            // if (timeElapsed >= cutoffMiddle && !penaltyMiddleGiven){
            //     PenaltyMiddle.SetActive(true);
            //     starCount -= 1;
            //     penaltyMiddleGiven = true;
            // }
            // if (timeElapsed >= cutoffLeft && !penaltyLeftGiven){
            //     PenaltyLeft.SetActive(true);
            //     penaltyLeftGiven = true;
            //     starCount -= 1;
            // }

            if (countDown <= cutoffRight && !penaltyRightGiven){
                PenaltyRight.SetActive(true);
                penaltyRightGiven = true;
                starCount -= 1;
            }
            if (countDown <= cutoffMiddle && !penaltyMiddleGiven){
                PenaltyMiddle.SetActive(true);
                penaltyMiddleGiven = true;
                starCount -= 1;
            }
            if (countDown <= cutoffLeft && !penaltyLeftGiven){
                // PenaltyLeft.SetActive(true);
                penaltyLeftGiven = true;
                // starCount -= 1;
                // Debug.Log("Start ball");
                countDown = 0.0f;
                timeElapsed = startCountDown;
                timerDone = true;

                if (timerAudio != null && timerAudio.isPlaying)
                    {
                        timerAudio.Stop();
                    }
                if(circle != null){
                    circle.GetComponent<BallMove>().Begin();
                }
                else if(circle2 != null){
                    circle2.GetComponent<BallMoveWithStickyPlatformPurple>().Begin();
                }
            }
            //if > star, activate cross out
        }

        
        //int f = (int)(timeElapsed * 100);
        int f = (int)(countDown * 100);
        float floatF = f/100.0f;

        textMP.text = $"{floatF}";
        if (isTutorialLevel==true && spaceButton != null){
            // if (floatF> (cutoffRight+0.5f)){
            // spaceButton.SetActive(true);
            // }
            if (floatF < (cutoffRight - 0.5f)){
                spaceButton.SetActive(true);
            }
        }
    }

    public int GetStarCount() {
        return starCount;
    }

    public float GetSpentTime() {
        int f = (int)(timeElapsed * 100);
        float floatF = f/100.0f;
        return floatF;
    }
}
