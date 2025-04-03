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
        //Debug.Log(rb.position);
        positions = new List<Vector2>();
        gameStarted = true;
    }

    void Update()
    {
        // rb.velocity = new Vector2(speed, rb.velocity.y - rb.gravityScale*Time.deltaTime);
        if (rb == null)
            return;
        
        elapsedTime += Time.deltaTime;
        if (gameStarted && elapsedTime > 0.2f){
            positions.Add(rb.position);
            Debug.Log(rb.position);
            elapsedTime = 0f;
        }
          
        
    }

    public static List<Vector2> GetPositions()
    {
        return positions;
    }
}
