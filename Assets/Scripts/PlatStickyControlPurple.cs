using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatStickyControlPurple : MonoBehaviour
{
    public GameObject playerSticky;
    Rigidbody2D rbSticky;
    Vector2 movement = new();
    public float horizSpeed = 4.0f;
    public float vertSpeed = 4.0f;
    public float angularSpeed = 50.0f;
    float origSwitchTimer = 0.35f;
    float switchTimer;

    void Start()
    {
        
        rbSticky = playerSticky.GetComponent<Rigidbody2D>();
        rbSticky.freezeRotation = true;
        switchTimer = origSwitchTimer;
    }

    // Update is called once per frame

    void Update(){

    }
    void FixedUpdate()
    {
        switchTimer -= Time.deltaTime;
        bool w = Input.GetKey(KeyCode.W);
        bool a = Input.GetKey(KeyCode.A);
        bool s = Input.GetKey(KeyCode.S);
        bool d = Input.GetKey(KeyCode.D);

        bool leftArrow = Input.GetKey(KeyCode.LeftArrow);
        bool rightArrow = Input.GetKey(KeyCode.RightArrow);
        
        movement = new Vector2((d ? horizSpeed : 0) + (a ? -horizSpeed : 0), (w ? vertSpeed : 0) + (s ? -vertSpeed: 0) );
        rbSticky.position += movement * Time.deltaTime;
        float rotation = (leftArrow ? angularSpeed : 0) + (rightArrow ? -angularSpeed : 0);
        rbSticky.rotation += rotation * Time.deltaTime;        
    }

    
    


}
