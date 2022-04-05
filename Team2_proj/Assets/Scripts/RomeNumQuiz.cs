using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomeNumQuiz : MonoBehaviour
{
    public Sprite itemImage;
    public bool isSolve;

    void Start()
    {
        isSolve = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSolve)
            QuizSlove();
    }

    void QuizSlove() {
        gameObject.SetActive(true);
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().getItem = gameObject;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().itemImage = itemImage;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().isGet = true;
        isSolve = false;
    }
}