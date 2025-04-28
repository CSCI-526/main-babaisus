using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 jumpForce;
    void Start()
    {
        jumpForce = new Vector2(transform.up.x, transform.up.y);
        jumpForce *= 10;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle")){
            Debug.Log("Jump hit, jump up");
            Rigidbody2D circleRb = collision.gameObject.GetComponent<Rigidbody2D>();
            //playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y + 10);
            circleRb.velocity += jumpForce;
            //playerRb.velocity = new Vector2(playerRb.velocity.x + 10 * transform.up.x, playerRb.velocity.y + 10);
        }
    }
}