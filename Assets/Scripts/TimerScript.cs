using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI textMP;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Penalty1;
    public GameObject Penalty2;
    public GameObject Penalty3;
    public static float timeElapsed;
    public bool timerStarted = false;
    public bool timerDone = false;

    public GameObject circle;
    public float circleSpeed = 4.0f;
    private float cutoff1;
    private float cutoff2;
    private float cutoff3;
    private bool penalty1Given = false;
    private bool penalty2Given = false;
    private bool penalty3Given = false;
    private int starCount;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0.0f;
        starCount = 3;
        cutoff1 = (float) Variables.Object(Star1).Get("cutoff");
        cutoff2 = (float) Variables.Object(Star2).Get("cutoff");
        cutoff3 = (float) Variables.Object(Star3).Get("cutoff");
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerDone){
            if (Input.GetKey(KeyCode.Space)){
                timerStarted = true;
                timerDone = true;
                Rigidbody2D rb = circle.GetComponent<Rigidbody2D>();
                rb.gravityScale = 1.0f;
                rb.velocity = new Vector2(circleSpeed, rb.velocity.y);
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
            if (timeElapsed >= cutoff1 && !penalty1Given){
                Penalty1.SetActive(true);
                penalty1Given = true;
                starCount -= 1;
            }
            if (timeElapsed >= cutoff2 && !penalty2Given){
                Penalty2.SetActive(true);
                starCount -= 1;
                penalty2Given = true;
            }
            if (timeElapsed >= cutoff3 && !penalty3Given){
                Penalty3.SetActive(true);
                penalty3Given = true;
                starCount -= 1;
            }
            //if > star, activate cross out
        }

        
        int f = (int)(timeElapsed * 100);
        float floatF = f/100.0f;
        textMP.text = $"Time: {floatF}";
    }

    public int GetStarCount() {
        return starCount;
    }
}
