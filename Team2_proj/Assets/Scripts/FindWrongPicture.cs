using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWrongPicture : MonoBehaviour
{
    public Animation anim;
    public bool isFocus;
    public Vector3 localPoint;
    bool flag = false;

    private void Start()
    {
        isFocus = false;
    }
    void Update()
    {
        if (isFocus == true)
        {
            SolveQuiz(localPoint);
        }
    }

    public void SolveQuiz(Vector3 localPoint)
    {
        //틀린 부분에 해당하는 좌표에 raycast가 충돌한 상태로 마우스 왼쪽 클릭을 하면 이벤트 발생
        if((localPoint.x <= 0.44 && localPoint.x >= 0.39)  && (localPoint.y >= 0.06 && localPoint.y <= 0.13))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (flag == false)
                {
                    anim = gameObject.GetComponent<Animation>();
                    anim.Play("Quiz1");
                    flag = true;
                }
            }
        }
        isFocus = false;
    }
}