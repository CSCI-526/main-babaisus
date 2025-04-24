using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 jumpForce;
    Rigidbody2D rb;
    void Start()
    {
        jumpForce = new Vector2(transform.up.x, transform.up.y);
        jumpForce *= 10;

        Transform parentTransform = transform.parent;
        if (parentTransform){
            GameObject parent = transform.parent.gameObject;
            if (parent){
                rb=parent.GetComponent<Rigidbody2D>();
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity=new Vector2(0,0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle")){
            Debug.Log("Jump hit, jump up");
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            //playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y + 10);
            playerRb.velocity += jumpForce;
            //playerRb.velocity = new Vector2(playerRb.velocity.x + 10 * transform.up.x, playerRb.velocity.y + 10);
        }
    }
}