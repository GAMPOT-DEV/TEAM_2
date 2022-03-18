using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundF : SolvePiano
{
    // Start is called before the first frame update
    public AudioSource Note_F;

    void Start()
    {
        Init();
        chordsNum = 4;
    }

    void OnMouseDown()
    {
        noteCount = gameObject.transform.parent.GetComponent<SolvePiano>().noteCount;
        Note_F.Play();
        Test();
        gameObject.transform.parent.GetComponent<SolvePiano>().noteCount = noteCount;
    }
}
