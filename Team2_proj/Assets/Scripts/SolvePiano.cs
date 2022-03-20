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

    public void Init()
    {
        songArr = new int[7] { 6, 5, 4, 5, 6, 6, 6 };
        playerArr = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
        noteCount = 0;
        isClear = false;
    }

    public void Test()
    {
        Debug.Log(noteCount);

        if (!isClear)
        {
            if (songArr[noteCount] == chordsNum)
            {
                playerArr[noteCount] = chordsNum;
                noteCount++;
                //Debug.Log("맞음");
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
                    //Debug.Log("틀림");
                }

            }
        }

        if (noteCount == 7)
        {
            isClear = true;
            Debug.Log("puzzle is solved");
            noteCount = 0;
        }

    }
}
