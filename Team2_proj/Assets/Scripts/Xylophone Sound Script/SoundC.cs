using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundC : SolvePiano
{
    public AudioSource Note_C;

    void Start()
    {
        Init();
        chordsNum = 1;
        noteCount = 0;
    }

    void OnMouseDown()
    {
        noteCount = gameObject.transform.parent.GetComponent<SolvePiano>().noteCount;
        Note_C.Play();
        Test();
        gameObject.transform.parent.GetComponent<SolvePiano>().noteCount = noteCount;
        
    }
}
