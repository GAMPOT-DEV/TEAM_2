using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz1_Play : MonoBehaviour
{
    Animation anim;
    public bool isPlay;
    // Start is called before the first frame update
    void Start()
    {
        isPlay = false;
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay == true)
        {
            anim.Play();
            isPlay = false;
        }
    }
}
