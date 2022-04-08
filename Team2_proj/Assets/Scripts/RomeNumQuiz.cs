using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomeNumQuiz : MonoBehaviour
{
    public bool isSolve;

    void Start()
    {
        isSolve = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSolve)
        {
            QuizSlove();
            gameObject.SetActive(false);
            isSolve = true;
        }
    }

    void QuizSlove() {
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().getItem = gameObject;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().itemImage = gameObject.GetComponent<Item>().itemImage;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().isGet = true;
    }
}