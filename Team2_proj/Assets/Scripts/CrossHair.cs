using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    public Sprite changeImg;
    public Sprite defaultImg;

    Image curImg;
    

    void Start()
    {
        curImg = gameObject.GetComponent<Image>();
        
    }

   

    /*public void ChangeImage()
    {

    }*/

}
