using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz1_before : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().getItem = gameObject;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().itemImage = gameObject.GetComponent<Item>().itemImage;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().isGet = true;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().isExist = true;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().curItem = gameObject;
        GameObject.Find("Quiz1_Picture(before)").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
