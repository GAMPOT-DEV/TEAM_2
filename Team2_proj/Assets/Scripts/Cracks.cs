using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cracks : MonoBehaviour
{
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.puzzleIndex["picture"] == 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        if(manager.puzzleIndex["book_red"] == 1)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }

        if(manager.puzzleIndex["Xylophone"] == 1)
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }

        if(manager.puzzleIndex["Report"] == 1)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
        }

        // if(manager.puzzleIndex["Report"] == 1)
        // {
        //     
        // }
    }
}
