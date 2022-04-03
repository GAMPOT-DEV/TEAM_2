using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportQuiz : MonoBehaviour
{
    public bool isSolved;
    GameObject bottleA, bottleB;

    // Start is called before the first frame update
    void Start()
    {
        isSolved = false;
        bottleA = GameObject.Find("Pill Bottle A");
        bottleB = GameObject.Find("Pill Bottle B");
    }

    public void ChangeTag()
    {
        bottleA.tag = "Grabable";
        bottleB.tag = "Grabable";
    }
}
