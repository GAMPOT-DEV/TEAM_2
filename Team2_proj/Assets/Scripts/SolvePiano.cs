using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvePiano : MonoBehaviour
{
    public int chordsNum;
    public int[] songArr;
    public int[] playerArr;
    public int noteCount;
    public bool isClear;
    public GameObject PianoBox;

    void Start()
    {
        Init();
        PianoBox = GameObject.Find("XylophoneBox");

    }
    public void Init()
    {
        songArr = new int[7] { 6, 5, 4, 5, 6, 6, 6 };
        playerArr = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        noteCount = 0;
        isClear = false;
    }

    public void Test(int chordsNum)
    {
        if (!isClear)
        {
            if (songArr[noteCount] == chordsNum)
            {
                playerArr[noteCount] = chordsNum;
                noteCount++;
            }

            else
            {
                if(chordsNum == 6)
                {
                    noteCount = 1;
                    playerArr = new int[7] { 6, 0, 0, 0, 0, 0, 0 };
                }
                else
                {
                    noteCount = 0;
                    playerArr = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                }

            }
        }

        if (noteCount == 7)
        {
            isClear = true;
            Debug.Log("puzzle is solved");
            PianoBox.GetComponentInChildren<PianoBox>().PlayAnim();
            noteCount = 0;
        }

    }


    public void Play_note(AudioSource note)
    {
        note.Play();
    }
}
