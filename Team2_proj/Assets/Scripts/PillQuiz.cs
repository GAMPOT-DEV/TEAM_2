using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillQuiz : MonoBehaviour
{
    public GameObject PillBottle_A;
    public GameObject PillBottle_B;
    public Transform Pill;
    Transform[] Pills = new Transform[4]; //...�� transform����?
    bool createPill = false;
    int QuizStep = 0;
    /*
     * 1. �ິ A�� ���� ��Ҵ���
     * 2. �ິ B�� ���� ��Ҵ���
     * 3. �ິ A�� ���� �ϳ� �� ��Ҵ���
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PillQuizStart()
    {

    }

    public void BottleOnTable()
    {
        if (QuizStep == 0)
        {
            if (PillBottle_A.GetComponent<PillBottle>().isGrabing == true)
            {
                PillBottle_A.GetComponent<PillBottle>().ChangePillPosition();
                createPill = true;
            }
            if (PillBottle_A.GetComponent<PillBottle>().isGrabing == false && createPill)
            {
                Pills[0] = Instantiate(Pill, new Vector3(-12.565f, 0.81f, 14.514f), Quaternion.identity);
                createPill = false;
                QuizStep++;
            }
        }
        else if(QuizStep == 1)
        {
            if (PillBottle_B.GetComponent<PillBottle>().isGrabing == true)
            {
                PillBottle_B.GetComponent<PillBottle>().ChangePillPosition();
                createPill = true;
            }
            if (PillBottle_B.GetComponent<PillBottle>().isGrabing == false && createPill)
            {
                Pills[1] = Instantiate(Pill, new Vector3(-12.4f, 0.81f, 14.514f), Quaternion.identity);
                Pills[2] = Instantiate(Pill, new Vector3(-12.4f, 0.81f, 14.4f), Quaternion.identity);
                createPill = false;
                QuizStep++;
            }
        }
        else if (QuizStep == 2)
        {
            if (PillBottle_A.GetComponent<PillBottle>().isGrabing == true)
            {
                PillBottle_A.GetComponent<PillBottle>().ChangePillPosition();
                createPill = true;
            }
            if (PillBottle_A.GetComponent<PillBottle>().isGrabing == false && createPill)
            {
                Pills[3] = Instantiate(Pill, new Vector3(-12.565f, 0.81f, 14.4f), Quaternion.identity);
                createPill = false;
                QuizStep++;
            }
        }
        if(QuizStep == 3)
        {
            IsSolved();
        }
    }

    //���� ���� �ν��� ��, ���� �ذ�
    public bool IsSolved()
    {
        for(int i=0; i<4; i++)
        {
            if (Pills[i].GetComponent<Pill>().IsBroken == false)
            {
                Debug.Log("Pill Quiz Not Solve");
                return false;
            }
        }
        Debug.Log("Pill Quiz is Solved");

        return true;
    }
}
