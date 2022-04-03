using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager myGameManger;
    public Dictionary<string, int> puzzleIndex;
    public float puzCount; //진행하면서 해결한 퍼즐 수

    // Start is called before the first frame update
    void Awake()
    {
        puzzleIndex = new Dictionary<string, int>();
        InitPuzzleIndex();
    }

    void Start()
    {
        puzCount = 0;
    }

    public void SendClearData(GameObject obj)
    {
        string tempKey = null;
        foreach(string key in puzzleIndex.Keys)
        {
            if(obj.name == key)
            {
                tempKey = key;
                break;
            }
        }
        puzzleIndex[tempKey] = 1;
        Debug.Log(puzzleIndex[tempKey]);
    }

    void InitPuzzleIndex()
    {
        //퍼즐의 초기 상태는 모두 안 풀려있음 -> 0이면 안풀림, 1이면 풀림
        puzzleIndex.Add("Xylophone", 0);
        puzzleIndex.Add("Lock", 0);
        puzzleIndex.Add("Report", 0);
        puzzleIndex.Add("Pill Bound", 0);
        //퍼즐의 프리팹 이름을 추가하고 주석에서 빼야함
        /*puzzleIndex.Add("", 0);
        puzzleIndex.Add("", 0);
        puzzleIndex.Add("", 0);
        puzzleIndex.Add("", 0);
        puzzleIndex.Add("", 0);
        puzzleIndex.Add("", 0);
        puzzleIndex.Add("", 0);

        */

    }


}
