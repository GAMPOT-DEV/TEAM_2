using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHighA : SolvePiano
{
    // Start is called before the first frame update
    public AudioSource Note_HighA;

    void Start()
    {
        Init();
        chordsNum = 6;
    }

    void OnMouseDown()
    {
        noteCount = gameObject.transform.parent.GetComponent<SolvePiano>().noteCount;
        Note_HighA.Play();
        Test();
        gameObject.transform.parent.GetComponent<SolvePiano>().noteCount = noteCount;
        gameObject.transform.parent.GetComponent<SolvePiano>().isClear = isClear;
    }
}
