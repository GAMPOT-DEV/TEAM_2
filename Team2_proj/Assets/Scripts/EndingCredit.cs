using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y >= 7500)
        {
            Application.Quit(); // 어플리케이션 종료
        }
        transform.position = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
    }
}
