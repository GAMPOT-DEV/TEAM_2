using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundD : SolvePiano
{
    public AudioSource Note_D;

    void Start()
    {
        Init();
        chordsNum = 2;
    }

    void OnMouseDown()
    {
        noteCount = gameObject.transform.parent.GetComponent<SolvePiano>().noteCount;
        Note_D.Play();
        Test();
        gameObject.transform.parent.GetComponent<SolvePiano>().noteCount = noteCount;
    }
}
