using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotationInTutorial : MonoBehaviour
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
    private bool gameStarted = false;
    private float elapsedTime = 0f;
    public static List<Vector2> positions; // tracking the positions of the platform
    
    public bool circleOverlapping;

    // Start is called before the first frame update
    void Start()
    {
        rbStill = playerStill.GetComponent<Rigidbody2D>();
        rbMoving = playerMoving.GetComponent<Rigidbody2D>();
        switchTimer = origSwitchTimer;
        positions = new List<Vector2>();
    }

    // Update is called once per frame

    void Update(){
        // switchTimer -= Time.deltaTime;
        if (!goTransparent){
            playerMoving.SetActive(true);
            playerStill.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        switchTimer -= Time.fixedDeltaTime;
        bool w = Input.GetKey(KeyCode.W);
        bool a = Input.GetKey(KeyCode.A);
        bool s = Input.GetKey(KeyCode.S);
        bool d = Input.GetKey(KeyCode.D);

        bool leftArrow = false;//Input.GetKey(KeyCode.LeftArrow);
        bool rightArrow = false;//Input.GetKey(KeyCode.RightArrow);

        if (w || a || s || d){
            gameStarted = true;
        }

        if (leftArrow || rightArrow){
            rbMoving.freezeRotation = true;
            rbStill.freezeRotation = true;
        }
        else{
            rbMoving.freezeRotation = true;
            rbStill.freezeRotation = true;
        }



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
                    if (!circleOverlapping){
                        if (switchTimer < 0.0f){
                            playerStill.SetActive(true);
                            playerMoving.SetActive(false);
                        }
                    }
                }
            }
        }


        // rbStill.position = rbMoving.position;
        // rbStill.rotation = rbMoving.rotation;

        // if (freeze){
        //     return;
        // }
        
        movement = new Vector2((d ? horizSpeed : 0) + (a ? -horizSpeed : 0), (w ? vertSpeed : 0) + (s ? -vertSpeed: 0) );
        //rbMoving.position += movement * Time.fixedDeltaTime;
        rbMoving.velocity = movement;// *Time.fixedDeltaTime;
        //rbMoving.MovePosition(movement * Time.fixedDeltaTime);
        float rotation = (leftArrow ? angularSpeed : 0) + (rightArrow ? -angularSpeed : 0);
        //rbMoving.rotation += rotation * Time.fixedDeltaTime;
        //rbMoving.angularVelocity = rotation;// * Time.fixedDeltaTime;
        //rbMoving.MoveRotation(rotation*Time.fixedDeltaTime);

        rbStill.position = rbMoving.position;
        rbStill.rotation = rbMoving.rotation;

        elapsedTime += Time.fixedDeltaTime;
        if (gameStarted && elapsedTime > 0.2f){
            positions.Add(rbMoving.position);
            //Debug.Log(rbMoving.position);
            elapsedTime = 0f;
        }



        
    }

    public static List<Vector2> GetPositions()
    {
        return positions;
    }

    public void SetCircleOverlapping(bool isOverlapping){
        circleOverlapping = isOverlapping;
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     GameObject maybeCircle = collision.gameObject;
    //     if (maybeCircle.CompareTag("Circle")){
    //         circleOverlapping = true;
    //     }
    // }

    // void OnTriggerStay2D(Collider2D collision)
    // {
    //     GameObject maybeCircle = collision.gameObject;
    //     if (maybeCircle.CompareTag("Circle")){
    //         circleOverlapping = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     GameObject maybeCircle = collision.gameObject;
    //     if (maybeCircle.CompareTag("Circle")){
    //         circleOverlapping = false;
    //     }
    // }

    // void OnCollisionEnter2D(Collision2D other){
    //     if (!other.gameObject.tag.Equals("Circle")){
    //         freeze = true;
    //     }
    //     else{
    //         // freeze = false;
    //     }
    // }
}
