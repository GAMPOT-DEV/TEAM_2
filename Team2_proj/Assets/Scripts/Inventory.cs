using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    bool isExist;
    public bool isGet;
    public bool[] itemCheck = new bool[7];
    public GameObject[] slots = new GameObject[7];
    public Sprite itemImage;
    public GameObject curSlot;
    public GameObject getItem;
    public GameObject curItem;
    void Start()
    {
        isExist = false;
        isGet = false;
        for(int i = 0;i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
            itemCheck[i] = false;
        }
        curSlot = slots[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isGet == true) {
            FindSlot();
            isGet = false;
            if (isExist == false)
                curItem = getItem;
            isExist = true;
        }
        if (isExist == true)
            ChangeSlot();
    }

    void FindSlot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(itemCheck[i] == false)
            {
                slots[i].GetComponent<Slot>().item = getItem;
                slots[i].GetComponent<Slot>().itemImage.sprite = itemImage;
                slots[i].GetComponent<Slot>().isFloat = true;
                itemCheck[i] = true;
                break;
            }
        }
    }

    void ChangeSlot()
    {
        curItem.transform.position = GameObject.Find("The Dest").transform.position;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SelectItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SelectItem(4);
        if (Input.GetKeyDown(KeyCode.Alpha6) && itemCheck[5] == true)
            SelectItem(5);
        if (Input.GetKeyDown(KeyCode.Alpha7) && itemCheck[6] == true)
            SelectItem(6);
    }

    void SelectItem(int index)
    {
        curItem.SetActive(false);
        if (itemCheck[index] == true)
        {
            curSlot = slots[index];
            curItem = curSlot.GetComponent<Slot>().item;
            curItem.SetActive(true);
        }
    }
}