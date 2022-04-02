using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MonologueManager : MonoBehaviour
{
    public GameObject panel;
    public Text myText;
    public GameObject player;
    public GameObject rayCastObj;
    public GameManager manager;


    [SerializeField]private MonoTextData data;

    private bool isActive;//텍스트가 표시중

    Dictionary<int, string[]> monoData;

    void Awake()
    {
        isActive = false;
        monoData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "FantasyRoom")
        {
            StartCoroutine(ShowText(1, 0));
        }
        else if (SceneManager.GetActiveScene().name == "RealityRoom")
        {
            StartCoroutine(ShowText(8, 0));
            StartCoroutine(ShowText(8, 1));
            StartCoroutine(ShowText(8, 2));
        }

        
        
        
    }
    void Update()
    {
        //플레이어의 raycast 정보를 가져옴
        rayCastObj = player.GetComponent<PlayerMovement>().rayObject;
        if(rayCastObj!=null)
        {
            data = rayCastObj.GetComponent<MonoTextData>();
            if(data!=null)
            {

            }
            
        }
        

    }

    //raycast가 충돌하고 텍스트를 출력할지 결정
    /*void RayCastInPuzzle()
    {
        if(data!=null)
        {
            switch(data.id)
            {
                case 1:

                    break;

                       

            }
        }
    }*/

    
    public void StartText(int id, int index)
    {
        StartCoroutine(ShowText(id, index));
    }

    IEnumerator ShowText(int id, int index)
    {
        //텍스트가 실행중이면 0.5초씩 기다리고, 텍스트가 사라졌을 때 새롭게 생성
        while(isActive)
        {
            yield return new WaitForSeconds(0.5f);

        }
        myText.text = monoData[id][index];
        isActive = true;
        yield return new WaitForSeconds(4.0f);
        myText.text = "";
        isActive = false;
    }

    void GenerateData()
    {
        //ID = 1, 게임 시작 후 검은화면에서 방이 보일 때
        monoData.Add(1, new string[] { "…꿈도 안 꾸고 푹 잤네." });

        //ID = 2, (최초)액자로 마우스 오버, 틀린그림찾기 해결 후
        monoData.Add(2, new string[] { "언제 봐도 예쁜 그림이야.", "그런데 왜 하필 지느러미가?" });

        //ID = 3, 액자 속 종이 클릭 후
        monoData.Add(3, new string[] { "이건 뭐지? 암호?" });

        //ID = 4, 실로폰 퍼즐 해결 후
        monoData.Add(4, new string[] { "어릴 때 이 노래 참 좋아했는데." });

        //ID = 5, 진단서 발견 후
        monoData.Add(5, new string[] { "진단서? 내가 병원에 간 적이 있었나?" });

        //ID = 6, 진단서를 들고 일정시간 이후, (최초)옷장 발견
        monoData.Add(6, new string[] { "머리가 아픈 것 같아.", "마지막으로 옷장을 연 것이 언제더라?" });

        //ID = 7, 
        monoData.Add(7, new string[] {  });

        //ID = 8, 분기점 이후, 순차적으로
        monoData.Add(8, new string[] { "머리가 깨질 것 같아.\n약 먹으면 괜찮아지는 것 아니었나?", "여긴 어디…? 내 방..?", "말도 안돼." });

        //ID = 9, 분기점 이전에 포스터를 클릭 시
        monoData.Add(9, new string[] { "참 예쁜 포스터야." });

        
        monoData.Add(10, new string[] { "" });
            

    }

    public string GetMono(int id, int monoIndex) //Object의 id , string배열의 index
    {
        return monoData[id][monoIndex]; //해당 아이디의 해당 대사
    }
}
