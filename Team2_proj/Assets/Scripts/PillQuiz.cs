using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PillQuiz : MonoBehaviour
{
    public GameObject PillBottle_A;
    public GameObject PillBottle_B;
    public Transform Pill;
    Transform[] Pills = new Transform[4]; //...�� transform����?
    bool createPill = false;
    int QuizStep = 0;
    public bool isSolved;

    /*
     * 1. �ິ A�� ���� ��Ҵ���
     * 2. �ິ B�� ���� ��Ҵ���
     * 3. �ິ A�� ���� �ϳ� �� ��Ҵ���
    */

    // Start is called before the first frame update
    void Start()
    {
        isSolved = false;
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
                Pills[0] = Instantiate(Pill, new Vector3(0f, 0.1f, 0f), Quaternion.identity);
                Pills[0].transform.SetParent(gameObject.transform, false);
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
                Pills[1] = Instantiate(Pill, new Vector3(1f, 0.1f, 0f), Quaternion.identity);
                Pills[2] = Instantiate(Pill, new Vector3(1f, 0.1f, 1f), Quaternion.identity);
                Pills[1].transform.SetParent(gameObject.transform, false);
                Pills[2].transform.SetParent(gameObject.transform, false);
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
                Pills[3] = Instantiate(Pill, new Vector3(0f, 0.1f, 1f), Quaternion.identity);
                Pills[3].transform.SetParent(gameObject.transform, false);
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
        if (!isSolved)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Pills[i].GetComponent<Pill>().IsBroken == false)
                {
                    Debug.Log("Pill Quiz Not Solve");
                    return false;
                }
            }
        }

        isSolved = true;
        SceneManager.LoadScene("RealityRoom");
        return true;
    }
}
