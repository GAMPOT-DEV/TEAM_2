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

    //�� �μ����� �ִϸ��̼� �߰� ����
}
