using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWrongPicture : MonoBehaviour
{
    public bool isFocus;
    public Vector3 localPoint;
    bool isSolved;

    private void Start()
    {
        isSolved = false;
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
        if ((localPoint.x >= -0.44 && localPoint.x <= -0.39)  && (localPoint.y >= 0.06 && localPoint.y <= 0.13))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isSolved == false)
                {
                    gameObject.GetComponentInParent<Quiz1_Play>().isPlay = true;
                    isSolved = true;
                }
            }
        }
    }
}