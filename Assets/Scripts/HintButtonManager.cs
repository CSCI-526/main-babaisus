using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButtonManager : MonoBehaviour
{
   public GameObject hintButton;
   private bool hintsShown = false;
   public static bool isHintTaken = false;


    void Start()
    {
        hintButton.GetComponent<Image>().enabled = true;
    }
    void Update()
    {
        
        hintButton.SetActive(true);
        if (PauseMenu.restartCounter > 2 && !hintsShown )
        {
            hintsShown = true;
            Debug.Log("Showing hint button");
            
            StartCoroutine(BlinkHintButton());
        }

        

    }

    public void ShowHint()
    {
        isHintTaken = true;
    }

    private IEnumerator BlinkHintButton()
    {
        for (int i = 0; i < 3; i++)
        {
           // Debug.Log("Blinking hint button");
            hintButton.GetComponent<Image>().enabled = true;
            yield return new WaitForSeconds(0.2f); 
            hintButton.GetComponent<Image>().enabled = false;
            yield return new WaitForSeconds(0.2f); 
        }
        hintButton.GetComponent<Image>().enabled = true;
       
    }
}
