using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatControlSizeChange : MonoBehaviour
{
    public GameObject playerStill;
    public GameObject playerMoving;
    Rigidbody2D rbStill;
    Rigidbody2D rbMoving;
    Vector2 movement = new();
    public float horizSpeed = 4.0f;
    public float vertSpeed = 4.0f;
    public float angularSpeed = 50.0f;
    public bool goTransparent = true;
    // bool freeze = false;
    float origSwitchTimer = 0.35f;
    float switchTimer;
    // Start is called before the first frame update

    // Random platform length change
    public float minLength = 0.5f;  // Minimum length (X-axis scale)
    public float maxLength = 2f;    // Maximum length (X-axis scale)
    public float changeInterval = 2f;  // Time interval to change size
    public float lerpSpeed = 2f;  // Speed of smooth transition

    private float targetLength;  
    private float timer = 0f;


    void Start()
    {
        rbStill = playerStill.GetComponent<Rigidbody2D>();
        rbMoving = playerMoving.GetComponent<Rigidbody2D>();
        switchTimer = origSwitchTimer;

        GenerateNewLength();
    }

    // Update is called once per frame

    void Update(){
        // switchTimer -= Time.deltaTime;
        if (!goTransparent){
            playerMoving.SetActive(true);
            playerStill.SetActive(true);
        }

        // Smoothly change only the X scale while keeping Y and Z the same
        Vector3 currentScale = transform.localScale;
        transform.localScale = new Vector3(Mathf.Lerp(currentScale.x, targetLength, Time.deltaTime * lerpSpeed), currentScale.y, currentScale.z);

        // Update timer
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            GenerateNewLength();
            timer = 0f; // Reset timer
        }
    }
    void FixedUpdate()
    {
        switchTimer -= Time.deltaTime;
        bool w = Input.GetKey(KeyCode.W);
        bool a = Input.GetKey(KeyCode.A);
        bool s = Input.GetKey(KeyCode.S);
        bool d = Input.GetKey(KeyCode.D);

        bool leftArrow = Input.GetKey(KeyCode.LeftArrow);
        bool rightArrow = Input.GetKey(KeyCode.RightArrow);

        if (goTransparent){
            if (w||a||s||d||leftArrow||rightArrow){
                if (!playerMoving.activeSelf){
                    if (switchTimer < 0.0f){
                        switchTimer = origSwitchTimer;
                    }
                }
                playerMoving.SetActive(true);
                playerStill.SetActive(false);

            }
            else{
                if (!playerStill.activeSelf ){
                    if (switchTimer < 0.0f){
                        playerStill.SetActive(true);
                        playerMoving.SetActive(false);
                    }
                }
            }
        }


        rbStill.position = rbMoving.position;
        rbStill.rotation = rbMoving.rotation;

        // if (freeze){
        //     return;
        // }
        
        movement = new Vector2((d ? horizSpeed : 0) + (a ? -horizSpeed : 0), (w ? vertSpeed : 0) + (s ? -vertSpeed: 0) );
        rbMoving.position += movement * Time.deltaTime;
        float rotation = (leftArrow ? angularSpeed : 0) + (rightArrow ? -angularSpeed : 0);
        rbMoving.rotation += rotation * Time.deltaTime;
    }

    void GenerateNewLength()
    {
        targetLength = Random.Range(minLength, maxLength);
    }
}
