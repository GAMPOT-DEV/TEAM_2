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
    private GameObject door;
    private Transform playerPos;
    


    void Start()
    {
        isClicked = false;
        player = GameObject.FindWithTag("Player");
        door = GameObject.Find("Box013");
        playerPos = player.transform;

        Init();
    }

    void Update()
    {
        ShowLock();
        ExitGame();
    }


    //자물쇠 띄우기
    void ShowLock()
    {
        if (isClicked && gameObject.tag != "SolvedPuzzle")
        {
            //커서 생성
            Cursor.visible = true;

            //자물쇠를 클릭하면 자물쇠 가까이 플레이어를 이동및 고정, 카메라 고정
            Camera playerCam = player.GetComponent<PlayerMovement>().playerCam;
            playerCam.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            playerPos.position = setDest.position;
            playerPos.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

            player.GetComponent<PlayerMovement>().isMoveable = false;

            //포커스한 동안은 collider 끄기
            //GetComponent<Collider>().enabled = false;

            isClicked = false;
        }
    }

    //게임 탈출
    void ExitGame()
    {
        //ESC로 나갈 때
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //커서 제거
            Cursor.visible = false;

            GetComponent<Collider>().enabled = true;
            player.GetComponent<PlayerMovement>().isMoveable = true;
        }
    }


    //자물쇠 정답, 플레이어의 현재 번호 정보
    public void Init()
    {
        lockArr = new int[] { 1, 2, 3, 4 };
        playerArr = new int[] { 1, 1, 1, 1 };
        chainNum = 0;
        playerNum = 1;
    }

    //클릭한 체인이 몇번째인지와, 그 번호에 대한 정보를 가져옴
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

        //퍼즐이 풀렸을 때, 태그를 puzzle->solved puzzle로 변경, 다시 퍼즐을 실행 못함
        if (count == 4)
        {
            //커서 제거
            Cursor.visible = false;

            GameObject.Find("GameManager").GetComponent<GameManager>().SendClearData(this.gameObject);
            Debug.Log("자물쇠가 풀림");
            GetComponent<Collider>().enabled = true;
            player.GetComponent<PlayerMovement>().isMoveable = true;
            door.GetComponent<Door>().OpenDoor();
            transform.tag = "SolvedPuzzle";
        }
       
    }
}
