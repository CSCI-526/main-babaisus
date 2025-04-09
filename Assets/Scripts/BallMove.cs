using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D rb;
    public static List<Vector2> positions; // tracking the positions of the ball
    private bool gameStarted = false;
    private float elapsedTime = 0f;
    private Vector2 lastPosition;
    private float stationaryTime = 0f; 
    public float stationaryThreshold = 15;
    public GameOverManager gameOverManager;

    private static bool hasStoppedFor5Seconds = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        positions = new List<Vector2>();
        lastPosition = rb.position;
        hasStoppedFor5Seconds = false;
        // rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Begin(){
        rb.gravityScale = 1.0f;
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //Debug.Log(rb.position);
        gameOverManager = FindObjectOfType<GameOverManager>();
        
        gameStarted = true;
        GameObject bucket = transform.GetChild(0).gameObject;
        bucket.GetComponent<BucketController2D>().TiltBucket();
        bucket.transform.SetParent(null);

    }

    void FixedUpdate()
    {
        // rb.velocity = new Vector2(speed, rb.velocity.y - rb.gravityScale*Time.deltaTime);
        if (rb == null)
            return;
        
        elapsedTime += Time.deltaTime;
        
        if (gameStarted)
        {
            
            if (rb.velocity.magnitude <0.1f)
            {
                stationaryTime += Time.deltaTime;
                // stop for 5 seconds
                if(stationaryTime >= 5f && !hasStoppedFor5Seconds) {
                    hasStoppedFor5Seconds = true;
                    // Debug.Log("Ball stopped for 5 sec");
                }

                if (stationaryTime >= stationaryThreshold)
                {
                    //Debug.Log("Ball is stationary for too long, GAME OVER");
                     gameOverManager.ShowGameOver();

                }
            }
            else
            {
                stationaryTime = 0f; 
                hasStoppedFor5Seconds = false;
            }

            lastPosition = rb.position; 
        }

        if (gameStarted && elapsedTime > 0.2f){
            positions.Add(rb.position);
            //Debug.Log(rb.position);
            elapsedTime = 0f;
        }
    }

    public static List<Vector2> GetPositions()
    {
        return positions;
    }

    public static bool ShouldAppearRestart() {
        return hasStoppedFor5Seconds;
    }
}
