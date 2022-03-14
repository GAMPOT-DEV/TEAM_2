using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoUI : MonoBehaviour
{
    public bool isUiOn;
    // Start is called before the first frame update
    void Start()
    {
        isUiOn = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.activeSelf);
        Debug.Log(isUiOn);
        if (isUiOn)
        {
            gameObject.SetActive(true);
            
        }
    }
}
