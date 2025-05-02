using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButtonManager : MonoBehaviour
{
   public GameObject hintButton;
   private bool hintsShown = false;
   public static bool isHintTaken = false;
    public GameObject disableHintButton;


    void Start()
    {
        hintButton.GetComponent<Image>().enabled = true;
        
    }
    void Update()
    {
        if (PauseMenu.restartCounter >= 0 && !hintsShown && PauseMenu.restartCounter <= 2 )
        {
        hintButton.SetActive(true);
        hintsShown = true;
        }
        if (PauseMenu.restartCounter > 2 && !hintsShown )
        {
            hintButton.SetActive(true);
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
            // Enable the hint button and disable the disable hint button
            hintButton.GetComponent<Image>().enabled = true;
            disableHintButton.SetActive(false);
            disableHintButton.GetComponent<Image>().enabled = false;
            yield return new WaitForSeconds(0.2f);

            // Disable the hint button and enable the disable hint button
            hintButton.GetComponent<Image>().enabled = false;
            disableHintButton.SetActive(true);
            disableHintButton.GetComponent<Image>().enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        hintButton.GetComponent<Image>().enabled = true;
       
    }
}
