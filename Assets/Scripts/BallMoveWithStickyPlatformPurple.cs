using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveWithStickyPlatformPurple : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D rb;

    public GameObject platform;
    private Transform ballTransform;
    private bool isOnPlatform = false;

    private bool isPaused = false;
    public float pauseDuration = 2f;
    private float pauseTimer = 0f;
    private Vector2 storedVelocity;
    private float storedAngularVelocity;
    private Vector2 ballOffset;
    private float ballRotationOffset;
    private bool isBallStuck = false;
    private Vector2 collisionNormal;
    private Vector2 ballOffsetLocal;
    public static List<Vector2> positions; // tracking the positions of the ball
    private bool gameStarted = false;
    private float elapsedTime = 0f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        positions = new List<Vector2>();

        ballTransform = transform;
    }

    public void Begin()
    {
        rb.gravityScale = 1.0f;
        rb.velocity = new Vector2(speed, rb.velocity.y);

        //positions = new List<Vector2>();
        gameStarted = true;
        GameObject bucket = transform.GetChild(0).gameObject;
        bucket.GetComponent<BucketController2D>().TiltBucket();
        bucket.transform.SetParent(null);
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == platform && !isBallStuck)
        {
            isOnPlatform = true;
            Debug.Log("Ball landed on platform.");

            // ballOffset = ballTransform.position - platform.transform.position;
            // ballRotationOffset = platform.transform.rotation.eulerAngles.z;

            ContactPoint2D contact = collision.contacts[0];  // Get collision contact point
            collisionNormal = contact.normal;  // Store the normal of the surface

            // ballOffset = (Vector2)ballTransform.position - contact.point;
            // ballRotationOffset = platform.transform.rotation.eulerAngles.z;

            ballOffsetLocal = platform.transform.InverseTransformPoint(contact.point);

            isBallStuck = true;

            PauseBallMovement();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == platform)
        {
            isOnPlatform = false;
            Debug.Log("Ball left the platform.");

            ResumeBallMovement();
        }
    }

    void FixedUpdate()
    {
        if (rb == null)
            return;
        elapsedTime += Time.deltaTime;

        if (isOnPlatform)
        {
            if (isPaused)
            {
                Vector3 platformPosition = platform.transform.position;

                Vector3 offsetWorld = platform.transform.TransformPoint(ballOffsetLocal);
                ballTransform.position = offsetWorld;
                
                // Quaternion platformRotation = platform.transform.rotation;

                // Vector3 offset3D = new Vector3(ballOffset.x, ballOffset.y, 0f);

                // Vector3 rotatedOffset = platformRotation * offset3D;

                // ballTransform.position = platformPosition + rotatedOffset;

                PauseTimerUpdate();
            }
            
        }

        if (gameStarted && elapsedTime > 0.2f){
            positions.Add(rb.position);
            //Debug.Log(rb.position);
            elapsedTime = 0f;
        }
    }

    void PauseBallMovement()
    {
        isPaused = true;

        storedVelocity = rb.velocity;
        storedAngularVelocity = rb.angularVelocity;

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;

        pauseTimer = pauseDuration;

        Debug.Log("Ball movement stopped.");
    }

    void ResumeBallMovement()
    {
        isPaused = false;
        rb.velocity = new Vector2(speed, rb.velocity.y);
        rb.gravityScale = 1f;
        Debug.Log("Ball movement enabled.");
    }

    void PauseTimerUpdate()
    {
        pauseTimer -= Time.deltaTime;
        if (pauseTimer <= 0f)
        {
            isPaused = false;
            ResumeBallMovement();
            Debug.Log("Ball movement resumed after pause.");
        }
    }

    public static List<Vector2> GetPositions()
    {
        return positions;
    }
}