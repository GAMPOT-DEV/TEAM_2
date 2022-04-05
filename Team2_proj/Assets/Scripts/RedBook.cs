using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBook : MonoBehaviour
{
    public bool isClicked;
    public GameObject paper;

    private bool alreadyClear;

    void Start() {
        isClicked = false;
        alreadyClear = false;
    }
    void Update() {
        {
            if(isClicked&&!alreadyClear)
            {
                alreadyClear = true;
                Vector3 rot = new Vector3(transform.rotation.x+90, transform.rotation.y, transform.rotation.z+10);
                isClicked = false;
                Instantiate(paper, transform.position + new Vector3(1, -0.7f, 0), Quaternion.Euler(rot));
            }
        }
    }
}
