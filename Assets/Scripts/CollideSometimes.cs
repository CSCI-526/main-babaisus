using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CollideSometimes : MonoBehaviour
{
    public GameObject platStill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if (!other.gameObject.tag.Equals("Circle")){
            platStill.SetActive(true);
            gameObject.SetActive(false);
        }
        else{
            platStill.SetActive(false);
            gameObject.SetActive(true);
        }
    }


}
