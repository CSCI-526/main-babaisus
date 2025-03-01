using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StarText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI starText;
    void Start()
    {
        starText.text = Variables.Object(gameObject).Get("cutoff").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
