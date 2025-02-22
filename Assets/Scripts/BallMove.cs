using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D rb;
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
}
