using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public bool IsBroken = false;
    public GameObject RightPill;

    public void PillBreak()
    {
        if (!IsBroken)
        {
            RightPill.transform.localPosition += new Vector3(-0.1f, 0f, 0f);
            IsBroken = true;
        }
    }

    //약 부서지는 애니메이션 추가 예정
}