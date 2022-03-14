using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWrongPicture : MonoBehaviour
{
    public bool isFocus;
    public Vector3 localPoint;

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
        //Ʋ�� �κп� �ش��ϴ� ��ǥ�� raycast�� �浹�� ���·� ���콺 ���� Ŭ���� �ϸ� �̺�Ʈ �߻�
        if((localPoint.x <= 0.44 && localPoint.x >= 0.39)  && (localPoint.y >= 0.06 && localPoint.y <= 0.13))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //�ӽ÷� log�� ���
                Debug.Log("Quiz Sloved!!");
            }
        }
        isFocus = false;
    }
}