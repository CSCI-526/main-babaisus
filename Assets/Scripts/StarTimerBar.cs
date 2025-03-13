using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTimerBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Device Type: " + UnityEngine.Device.SystemInfo.deviceType );
        if (UnityEngine.Device.SystemInfo.deviceType == DeviceType.Handheld)
        {

            RectTransform rectTransform = GetComponent<RectTransform>();
            if (rectTransform != null)
            {

                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 79);
                rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            else
            {
                Debug.LogError("RectTransform component error");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
