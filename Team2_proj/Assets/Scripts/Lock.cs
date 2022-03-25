using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public bool isClicked;
    public Transform setDest;
    public int chainNum;
    public int playerNum;
    public int[] lockArr;
    public int[] playerArr;

    private GameObject player;
    private Transform playerPos;
    private bool isClear;
    


    void Start()
    {
        isClicked = false;
        isClear = false;
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform;

        Init();
    }

    void Update()
    {
        ShowLock();
        ExitGame();
    }


    //�ڹ��� ����
    void ShowLock()
    {
        if (isClicked && gameObject.tag != "SolvedPuzzle")
        {
            //�ڹ��踦 Ŭ���ϸ� �ڹ��� ������ �÷��̾ �̵��� ����, ī�޶� ����
            Camera playerCam = player.GetComponent<PlayerMovement>().playerCam;
            playerCam.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            playerPos.position = setDest.position;
            playerPos.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

            player.GetComponent<PlayerMovement>().isMoveable = false;

            //��Ŀ���� ������ collider ����
            //GetComponent<Collider>().enabled = false;

            isClicked = false;
        }
    }

    //���� Ż��
    void ExitGame()
    {
        //ESC�� ���� ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Collider>().enabled = true;
            player.GetComponent<PlayerMovement>().isMoveable = true;
        }

        //������ Ǯ���� ��, �±׸� puzzle->solved puzzle�� ����, �ٽ� ������ ���� ����
        else if (isClear)
        {
            GetComponent<Collider>().enabled = true;
            player.GetComponent<PlayerMovement>().isMoveable = true;
            transform.tag = "SolvedPuzzle";
        }
    }


    //�ڹ��� ����, �÷��̾��� ���� ��ȣ ����
    public void Init()
    {
        lockArr = new int[] { 1, 2, 3, 4 };
        playerArr = new int[] { 1, 1, 1, 1 };
        chainNum = 0;
        playerNum = 1;
    }

    //Ŭ���� ü���� ���°������, �� ��ȣ�� ���� ������ ������
    public void TestLock(int chainNum,int playerNum)
    {
        transform.GetComponentInParent<Lock>().playerArr[chainNum] = playerNum;

        int count = 0;
        for(int i = 0; i < 4 ; i++)
        {
            if(transform.GetComponentInParent<Lock>().lockArr[i] == transform.GetComponentInParent<Lock>().playerArr[i])
            {
                count++;
            }
        }

        if(count == 4)
        {
            isClear = true;
            Debug.Log("�ڹ��谡 Ǯ��");
        }
       
    }
}