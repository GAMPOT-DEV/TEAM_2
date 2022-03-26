using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool isGet;
    public bool[] itemCheck = new bool[7];
    public GameObject[] slots = new GameObject[7];
    public Sprite itemImage;
    void Start()
    {
        isGet = false;
        for(int i = 0;i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
            itemCheck[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGet == true) {
            FindSlot();
            isGet = false;
        }
    }

    void FindSlot()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(itemCheck[i] == false)
            {
                Debug.Log(itemCheck[i]);
                slots[i].GetComponentInChildren<Slot>().itemImage.sprite = itemImage;
                slots[i].GetComponent<Slot>().isFloat = true;
                itemCheck[i] = true;
                break;
            }
        }
    }
}