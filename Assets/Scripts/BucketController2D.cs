using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController2D : MonoBehaviour
{
    // Start is called before the first frame 
    public GameObject ball;  // Assign the ball in the Inspector
    public float holdTime = 3f;  // Time before tilting
    public float tiltAngle = 70f; // How much the bucket tilts
    public float tiltSpeed = 4f;  // Speed of tilting

    private bool hasTilted = false;
    private Rigidbody2D ballRb;


    void Start()
    {
        //transform.SetParent(null);
        if (ball != null)
        {
            ballRb = ball.GetComponent<Rigidbody2D>();
            HoldBall();
            Invoke("TiltBucket", holdTime);  // Automatically tilt after holdTime
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (!hasTilted && Input.GetKeyDown(KeyCode.Space))
        // {
        //     TiltBucket();
        // }
    }

    void HoldBall()
    {
        if (ballRb != null)
        {
            ballRb.isKinematic = true;  // Stop ball physics
            ball.transform.SetParent(transform);  // Attach ball to bucket
        }
    }

    public void TiltBucket()
    {
        if (!hasTilted)
        {
            hasTilted = true;
            StartCoroutine(TiltCoroutine());
        }
    }

     IEnumerator TiltCoroutine()
    {
        float elapsedTime = 0f;
        float duration = 1f / tiltSpeed; // Smooth transition duration

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, -tiltAngle); // Tilt left

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure it reaches final rotation

        // Release the ball after tilting
        if (ballRb != null)
        {
            Debug.Log("Releasing the ball...");
            ballRb.isKinematic = false;  // Enable physics
            ball.transform.SetParent(null);  // Detach ball
        }
    }
}
