using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackAndWhiteFilter : MonoBehaviour
{
    [SerializeField]
    private GameObject filter;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("black_and_white", 0) == 1)
        {
            filter.SetActive(true);
        }
    }
    
    public void Toggle(bool value)
    {
        filter.SetActive(value);
    }
}
