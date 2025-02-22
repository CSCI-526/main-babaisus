using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 jumpForce = new Vector2(0, 1);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle")){
            Debug.Log("Jump hit, jump up");
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y + 10);
        }
    }
}