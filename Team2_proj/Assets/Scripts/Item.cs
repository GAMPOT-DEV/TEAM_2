using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public bool isClick;
    public bool isGet;
    public Sprite itemImage;
    void Start()
    {
        isClick = false;
        isGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick && (isGet == false))
        {
            getItem();
            isClick = false;
            isGet = true;
        }
    }

    void getItem()
    {
        gameObject.SetActive(false);
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().getItem = gameObject;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().itemImage = itemImage;
        GameObject.Find("Inventory_setting").GetComponent<Inventory>().isGet = true;
        gameObject.transform.SetParent(GameObject.Find("The Dest").transform);
    }
}