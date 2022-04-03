using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomeNumQuiz : MonoBehaviour
{
    public Sprite itemImage; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void QuizSlove() {
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().getItem = gameObject;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().itemImage = itemImage;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().isGet = true;
    }
}
