using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    public bool isFocus;
    public Sprite focusImg;
    public Sprite defaultImg;

    Image curImg;
    

    void Start()
    {
        curImg = gameObject.GetComponent<Image>();
        isFocus = false;
    }

    void Update()
    {
        if (isFocus)
            curImg.sprite = focusImg;
        else
            curImg.sprite = defaultImg;
    }
}