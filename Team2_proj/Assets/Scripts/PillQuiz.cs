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
         1. 알약통을 들고 특정 영역에 도달했는지 검사
         true -> 알약을 1개 넘어뜨릴 것 -> A 약통 수행 완료 확인 -> 2
         false -> 원상복구(grab 상태)
         2. 알약통을 
         */
    }

    public void BottleOnTable()
    {
        
        if(PillBottle.GetComponent<PillBottle>().isGrabing == true)
        {
            PillBottle.GetComponent<PillBottle>().ChangePillPosition();
        }
    }

    //약을 전부 부쉈을 때, 문제 해결
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
