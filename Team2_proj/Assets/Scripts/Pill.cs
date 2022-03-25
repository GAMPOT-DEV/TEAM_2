using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public bool IsBroken = false;

    public void PillBreak()
    {
        IsBroken = true;
    }

    //약 부서지는 애니메이션 추가 예정
}
