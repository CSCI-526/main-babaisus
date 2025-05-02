using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyPrevention : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject maybeCircle = collision.gameObject;
        if (maybeCircle.CompareTag("Circle")){
            PlatControl script = player.GetComponent<PlatControl>();
            if (script){
                script.SetCircleOverlapping(true);
            }
            else{
                player.GetComponent<FreezeRotationInTutorial>().SetCircleOverlapping(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject maybeCircle = collision.gameObject;
        if (maybeCircle.CompareTag("Circle")){
            player.GetComponent<PlatControl>().SetCircleOverlapping(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject maybeCircle = collision.gameObject;
        if (maybeCircle.CompareTag("Circle")){
            player.GetComponent<PlatControl>().SetCircleOverlapping(false);
        }
    }
}
