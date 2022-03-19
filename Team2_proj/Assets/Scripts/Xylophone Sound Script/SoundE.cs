using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundE : SolvePiano
{
    public AudioSource Note_E;

    void Start()
    {
        Init();
        chordsNum = 3;
    }

    void OnMouseDown()
    {
        noteCount = gameObject.transform.parent.GetComponent<SolvePiano>().noteCount;
        Note_E.Play();
        Test();
        gameObject.transform.parent.GetComponent<SolvePiano>().noteCount = noteCount;

        
    }
}
