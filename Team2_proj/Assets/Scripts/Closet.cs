using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    public bool isClicked;
    public bool isOpen;
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isClicked)
        {
            
            isClicked = false;
            anim.Play();
        }
    }
}
