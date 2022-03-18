using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundG : SolvePiano
{
    // Start is called before the first frame update
    public AudioSource Note_G;

    void Start()
    {
        Init();
        chordsNum = 5;
    }

    void OnMouseDown()
    {
        noteCount = gameObject.transform.parent.GetComponent<SolvePiano>().noteCount;
        Note_G.Play();
        Test();
        gameObject.transform.parent.GetComponent<SolvePiano>().noteCount = noteCount;
    }
}
