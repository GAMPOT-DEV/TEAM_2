using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Credit());
    }

    IEnumerator Credit()
    {
        while(transform.position.y <= 10000)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Application.Quit();
        Debug.Log("hello");
    }
}
