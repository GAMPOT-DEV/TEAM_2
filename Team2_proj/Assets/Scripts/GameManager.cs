using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager myGameManger;
    public Dictionary<string, int> puzzleIndex;
    public float puzCount; //�����ϸ鼭 �ذ��� ���� ��

    // Start is called before the first frame update
    void Awake()
    {
        puzzleIndex = new Dictionary<string, int>();
        InitPuzzleIndex();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        //������ �ʱ� ���´� ��� �� Ǯ������ -> 0�̸� ��Ǯ��, 1�̸� Ǯ��
        puzzleIndex.Add("Xylophone", 0);
        puzzleIndex.Add("Lock", 0);
        puzzleIndex.Add("Report", 0);
        puzzleIndex.Add("picture", 0);
        puzzleIndex.Add("book_red", 0);
        puzzleIndex.Add("Pill Bound", 0);
        //������ ������ �̸��� �߰��ϰ� �ּ����� ������
        /*puzzleIndex.Add("Pill Bound", 0);
        */

    }


}
