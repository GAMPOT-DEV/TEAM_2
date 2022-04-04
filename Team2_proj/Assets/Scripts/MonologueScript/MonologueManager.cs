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

    private bool isActive;//�ؽ�Ʈ�� ǥ����

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
        //�÷��̾��� raycast ������ ������
        rayCastObj = player.GetComponent<PlayerMovement>().rayObject;
        if(rayCastObj!=null)
        {
            data = rayCastObj.GetComponent<MonoTextData>();
            if(data!=null)
            {

            }
            
        }
        

    }

    //raycast�� �浹�ϰ� �ؽ�Ʈ�� ������� ����
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
        //�ؽ�Ʈ�� �������̸� 0.5�ʾ� ��ٸ���, �ؽ�Ʈ�� ������� �� ���Ӱ� ����
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
        //ID = 1, ���� ���� �� ����ȭ�鿡�� ���� ���� ��
        monoData.Add(1, new string[] { "…꿈도 안 꾸고 푹 잤네." });

        //ID = 2, (����)���ڷ� ���콺 ����, Ʋ���׸�ã�� �ذ� ��
        monoData.Add(2, new string[] { "언제 봐도 예쁜 그림이야.","그런데 왜 하필 지느러미가?" });

        //ID = 3, ���� �� ���� Ŭ�� ��
        monoData.Add(3, new string[] { "이건 뭐지? 암호?" });

        //ID = 4, �Ƿ��� ���� �ذ� ��
        monoData.Add(4, new string[] { "어릴 때 이 노래 참 좋아했는데." });

        //ID = 5, ���ܼ� �߰� ��
        monoData.Add(5, new string[] { "진단서? 내가 병원에 간 적이 있었나?" });

        //ID = 6, ���ܼ��� ��� �����ð� ����, (����)���� �߰�
        monoData.Add(6, new string[] { "머리가 아픈 것 같아."});

        //ID = 7, 
        monoData.Add(7, new string[] { "마지막으로 옷장을 연 것이 언제더라?" });

        //ID = 8, �б��� ����, ����������
        monoData.Add(8, new string[] { "머리가 깨질 것 같아.\n약 먹으면 괜찮아지는 것 아니었나?", "여긴 어디…? 내 방..?", "말도 안돼." });

        //ID = 9, �б��� ������ �����͸� Ŭ�� ��
        monoData.Add(9, new string[] { "�� ���� �����;�." });

        
        monoData.Add(10, new string[] { "" });
            

    }

    public string GetMono(int id, int monoIndex) //Object�� id , string�迭�� index
    {
        return monoData[id][monoIndex]; //�ش� ���̵��� �ش� ���
    }
}
