using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillBottle : grabObject
{
    Vector3 StartPosition;

    void Start()
    {
        isGrabing = false;
        isGrabable = false;
        isPuzzle = false;

        StartPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RayCollide();
    }

    public void ChangePillPosition()
    {
        isGrabing = false;
        transform.parent = null;

        gameObject.transform.position = new Vector3(-9.28f, 3.5f, -7.9f);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(-120f, 0f, 0f));
    }

    public void GrabBottle()
    {
        isGrabing = true;
        RayCollide();
    }

    public void GrabOutBottle()
    {
        gameObject.transform.position = StartPosition;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }
}
