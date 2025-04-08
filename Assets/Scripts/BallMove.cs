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
    private float stoppedTime = 0f;
    private static bool hasStoppedFor2Seconds = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        positions = new List<Vector2>();
        hasStoppedFor2Seconds = false;
        stoppedTime = 0f;
        // rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Begin(){
        rb.gravityScale = 1.0f;
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //Debug.Log(rb.position);
        
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
        if (gameStarted && elapsedTime > 0.2f){
            positions.Add(rb.position);
            //Debug.Log(rb.position);
            elapsedTime = 0f;
        }

        if(gameStarted)
        {
            if(rb.velocity.magnitude < 0.01f) {
                stoppedTime += Time.deltaTime;
                if(stoppedTime >= 2f && !hasStoppedFor2Seconds) {
                    hasStoppedFor2Seconds = true;
                    Debug.Log("Ball stopped for 2 sec");
                }
            } else {
                stoppedTime = 0f;
                hasStoppedFor2Seconds = false;
            }
        }
          
        
    }

    public static List<Vector2> GetPositions()
    {
        return positions;
    }

    public static bool ShouldAppearRestart() {
        return hasStoppedFor2Seconds;
    }
}
