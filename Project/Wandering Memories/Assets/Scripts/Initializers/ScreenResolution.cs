using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string desiredResolution = PlayerPrefs.GetString("resolution", "1920x1080");
        string[] split = desiredResolution.Split('x');
        int desiredWidth = int.Parse(split[0]);
        int desiredHeight = int.Parse(split[1]);

        Resolution currentResolution = Screen.currentResolution;
        int currentWidth = currentResolution.width;
        int currentHeight = currentResolution.height;

        if (currentWidth != desiredWidth || currentHeight != desiredHeight)
        {
            Screen.SetResolution(desiredWidth, desiredHeight, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
