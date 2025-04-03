using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StarText : MonoBehaviour
{
    // Start is called before the first frame update
    public float cutoff = 0.0f;
    public TextMeshProUGUI starText;
    
    void Start()
    {
        //starText.text = cutoff.ToSafeString(); //;Variables.Object(gameObject).Get("cutoff").ToString();
        GameObject wrapper = transform.parent.gameObject;

        if (starText.text.Equals("Left")){
            cutoff = 0.0f; //(float) Variables.Object(wrapper).Get("leastTime");
        }
        else if (starText.text.Equals("Middle")){
            cutoff = (float) Variables.Object(wrapper).Get("mediumTime");
        }
        else if (starText.text.Equals("Right")){
            cutoff = (float) Variables.Object(wrapper).Get("mostTime");
        }
        starText.text = $"{cutoff}s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
