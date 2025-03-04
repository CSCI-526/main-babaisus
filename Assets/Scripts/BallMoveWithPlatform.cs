using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveWithPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.5f;
    private Rigidbody2D rb;
    private Vector2 originalVelocity;
    private bool isPaused = false;
    private int counter = 0;
    private Transform platformTransform;
    public float stickyTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        // rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Begin(){
        rb.gravityScale = 1.0f;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = new Vector2(speed, rb.velocity.y - rb.gravityScale*Time.deltaTime);
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        PlatControlSpeedChange platform = collision.gameObject.GetComponent<PlatControlSpeedChange>();
        platformTransform = collision.transform;
        
        if (collision.gameObject.CompareTag("GreenPlatform") && !isPaused && counter == 0)
        {
            counter += 1;
            Debug.Log("Ball touched green platform!");
            StartCoroutine(PauseOnGreenPlatform());
        }
        else if(counter > 0){
            
            platform.playerStill.tag = "Untagged";
            platform.playerMoving.tag = "Untagged";
        }
    }

    IEnumerator PauseOnGreenPlatform()
    {
        isPaused = true;

        originalVelocity = rb.velocity;
        Debug.Log($"Pausing ball. Original velocity: {originalVelocity}");
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        Vector3 initialPlatformPosition = platformTransform.position;
        Vector3 initialRelativePosition = transform.position - initialPlatformPosition;

        float elapsedTime = 0f;
        while (elapsedTime < stickyTime)
        {
            transform.position = platformTransform.position + initialRelativePosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // yield return new WaitForSeconds(2f);

        rb.isKinematic = false;
        rb.velocity = originalVelocity;
        Debug.Log($"Resuming ball movement with velocity: {rb.velocity}");
        isPaused = false;
    }
}
