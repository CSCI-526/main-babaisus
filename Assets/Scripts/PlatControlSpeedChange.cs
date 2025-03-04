using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatControlSpeedChange : MonoBehaviour
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

    // Color States
    private Color[] platformColors = new Color[] { Color.white, Color.red, Color.green };
    private int currentColorIndex = 0;
    private Renderer playerStillRenderer;
    private Renderer playerMovingRenderer;
    public float fastSpeed = 6.0f;

    void Start()
    {
        rbStill = playerStill.GetComponent<Rigidbody2D>();
        rbMoving = playerMoving.GetComponent<Rigidbody2D>();

        playerStillRenderer = playerStill.GetComponent<Renderer>();
        playerMovingRenderer = playerMoving.GetComponent<Renderer>();

        switchTimer = origSwitchTimer;
    }

    // Update is called once per frame

    void Update(){

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentColorIndex = (currentColorIndex + 1) % platformColors.Length;
            ChangePlatformColor();
        }

        // switchTimer -= Time.deltaTime;
        if (!goTransparent){
            playerMoving.SetActive(true);
            playerStill.SetActive(true);
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
            // If the platform color is green, do not switch transparency
            if (currentColorIndex == 2) // Green color index
            {
                playerStill.SetActive(true);
                playerMoving.SetActive(true);
            }
            else{
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
        }


        rbStill.position = rbMoving.position;
        rbStill.rotation = rbMoving.rotation;

        // if (freeze){
        //     return;
        // }

        // Adjust speed based on current platform color
        AdjustSpeedBasedOnColor();
        
        movement = new Vector2((d ? horizSpeed : 0) + (a ? -horizSpeed : 0), (w ? vertSpeed : 0) + (s ? -vertSpeed: 0) );
        rbMoving.position += movement * Time.deltaTime;
        float rotation = (leftArrow ? angularSpeed : 0) + (rightArrow ? -angularSpeed : 0);
        rbMoving.rotation += rotation * Time.deltaTime;

        
    }

    // Method to change the platform color
    void ChangePlatformColor()
    {
        Color newColor = platformColors[currentColorIndex];
        playerStillRenderer.material.color = newColor;
        playerMovingRenderer.material.color = newColor;

        if (newColor == Color.green)
        {
            // Debug.Log("newColor: ", newColor);
            playerStill.tag = "GreenPlatform";
            playerMoving.tag = "GreenPlatform";
        }
        else
        {
            playerStill.tag = "Untagged";
            playerMoving.tag = "Untagged";
        }
        
    }

    void AdjustSpeedBasedOnColor()
    {
        if (currentColorIndex == 1) // Red color
        {
            horizSpeed = fastSpeed; // Faster speed
            vertSpeed = fastSpeed;
        }

        else // White color
        {
            horizSpeed = 4.0f; // Default speed
            vertSpeed = 4.0f;
        }
    }
}
