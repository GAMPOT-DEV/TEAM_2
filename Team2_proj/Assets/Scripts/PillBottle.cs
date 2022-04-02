using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillBottle : grabObject
{
    // Start is called before the first frame update
    void Start()
    {
        isGrabing = false;
        isGrabable = false;
        isPuzzle = false;
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        RayCollide();
    }

    public void ChangePillPosition()
    {
        gameObject.transform.position = new Vector3(0.99f, 1.183f, 9.211f);
        gameObject.transform.eulerAngles = new Vector3(0f, 0f, 122.378f);
    }
}
