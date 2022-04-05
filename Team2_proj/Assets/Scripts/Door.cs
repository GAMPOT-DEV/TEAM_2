using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animation anim;

    public void OpenDoor()
    {
        anim.Play();
    }
}
