using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : grabObject
{
    public bool isClicked;
    //public GameObject piano;
    public Transform setDest;
    public GameObject PianoPanel;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        isGrabing = false;
        isGrabable = false;
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform;


    }

    // Update is called once per frame
    void Update()
    {
        
        HighlightPuzzle();
        ShowPiano();
        ExitGame();
    }

    
    void ShowPiano() //피아노가 클릭됐을 때 피아노 건반을 띄움
    {
        if(isClicked&&gameObject.tag!="SolvedPuzzle")
        {
            //플레이어를 실로폰 앞으로 옮긴 후, big sylophone 생성, 위치&카메라 방향 고정
            Camera playerCam = player.GetComponent<PlayerMovement>().playerCam;
            playerPos.position = setDest.position;
            playerPos.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            playerCam.transform.localEulerAngles = new Vector3(60f, 0f, 0f);

            player.GetComponent<PlayerMovement>().isMoveable = false;

            //피아노 UI 를 띄움
            PianoPanel.SetActive(true);

            isClicked = false;
        }
        
    }



    //ESC를 누르면 퍼즐에서 나감
    void ExitGame()
    {
        //ESC로 나갈 때
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<PlayerMovement>().isMoveable = true;
            this.transform.GetChild(1).GetComponent<Renderer>().enabled = true;

            PianoPanel.SetActive(false);
        }

        //퍼즐이 풀렸을 때, 태그를 puzzle->solved puzzle로 변경, 다시 퍼즐을 실행 못함
        else if (PianoPanel.GetComponent<SolvePiano>().isClear)
        {
            player.GetComponent<PlayerMovement>().isMoveable = true;
            PianoPanel.SetActive(false);
            transform.tag = "SolvedPuzzle";
        }
    }
}
