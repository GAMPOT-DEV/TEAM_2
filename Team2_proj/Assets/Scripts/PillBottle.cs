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
        gameObject.transform.position = new Vector3(-9.28f, 3.5f, -7.9f);
        gameObject.transform.eulerAngles = new Vector3(-120f, 0f, 0f);
    }
}
