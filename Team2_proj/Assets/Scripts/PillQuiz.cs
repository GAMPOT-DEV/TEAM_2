using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillQuiz : MonoBehaviour
{
    public GameObject PillBottle;
    public Pill Pill1, Pill2, Pill3, Pill4;

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
        /*
         1. �˾����� ��� Ư�� ������ �����ߴ��� �˻�
         true -> �˾��� 1�� �Ѿ�߸� �� -> A ���� ���� �Ϸ� Ȯ�� -> 2
         false -> ���󺹱�(grab ����)
         2. �˾����� 
         */
    }

    public void BottleOnTable()
    {
        
        if(PillBottle.GetComponent<PillBottle>().isGrabing == true)
        {
            PillBottle.GetComponent<PillBottle>().ChangePillPosition();
        }
    }

    //���� ���� �ν��� ��, ���� �ذ�
    public bool IsSolved()
    {
        if (!Pill1.IsBroken)
            return false;
        if (!Pill2.IsBroken)
            return false;
        if (!Pill3.IsBroken)
            return false;
        if (!Pill4.IsBroken)
            return false;
        return true;
    }
}
