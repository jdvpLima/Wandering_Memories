using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Display_Menu : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private TMP_Dropdown dropdown;

    private BlackAndWhiteFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        GameObject filterObject = GameObject.Find("BlackAndWhiteFilter");
        filter = filterObject.GetComponent<BlackAndWhiteFilter>();
        int filterOn = PlayerPrefs.GetInt("black_and_white", 0);
        toggle.isOn = filterOn == 1;

        string resolution = PlayerPrefs.GetString("resolution", "1920x1080");
        int index = dropdown.options.FindIndex(option => option.text == resolution);
        dropdown.value = index;
    }

    public void ToggleFilter()
    {
        bool value = toggle.isOn;
        filter.Toggle(value);
        PlayerPrefs.SetInt("black_and_white", value ? 1 : 0);
    }

    public void ChangeResolution()
    {
        string desiredResolution = dropdown.options[dropdown.value].text;
        string[] split = desiredResolution.Split('x');
        int desiredWidth = int.Parse(split[0]);
        int desiredHeight = int.Parse(split[1]);

        Screen.SetResolution(desiredWidth, desiredHeight, true);
        PlayerPrefs.SetString("resolution", desiredResolution);
    }
}
