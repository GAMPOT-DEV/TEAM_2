using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    bool changeExist;
    public bool isDetail;
    bool isExist;
    public bool isGet;
    public bool[] itemCheck = new bool[7];
    public GameObject[] slots = new GameObject[7];
    public Sprite itemImage;
    public GameObject curSlot;
    public GameObject getItem;
    public GameObject curItem;
    public GameObject TopView_UI;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        TopView_UI = GameObject.Find("TopView_UI");
        isExist = false;
        isGet = false;
        isDetail = false;
        changeExist = false;
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
        if (isExist == true && isDetail == false)
        {
            ChangeSlot();
        }
        if (changeExist == true)
        {
            ImageDetail();
        }
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
        {
            SelectItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectItem(6);
        }
    }

    void SelectItem(int index)
    {
        curItem.SetActive(false);
        if (itemCheck[index] == true)
        {
            curSlot = slots[index];
            curItem = curSlot.GetComponent<Slot>().item;
            curItem.SetActive(true);
            changeExist = true;
            return;
        }
        changeExist = false;
    }

    void ImageDetail()
    {
        if (Input.GetKeyDown(KeyCode.R) && (isDetail == false))
        {
            player.GetComponent<PlayerMovement>().isMoveable = false;
            if (curItem.name == "phone")
            {
                TopView_UI.GetComponent<Image>().sprite = curItem.GetComponent<Image>().sprite;
                TopView_UI.GetComponent<Image>().enabled = true;
                isDetail = true;
                curItem.GetComponent<Quiz6>().isSolve = true;
            }
            else
            {
                TopView_UI.GetComponent<Image>().sprite = curItem.GetComponent<Item>().itemImage;
                TopView_UI.GetComponent<Image>().enabled = true;
                isDetail = true;
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.Escape) && (isDetail == true))
        {
            TopView_UI.GetComponent<Image>().enabled = false;
            player.GetComponent<PlayerMovement>().isMoveable = true;
            isDetail = false;
        }
        */
    }

    public void ExitDetail()
    {
        TopView_UI.GetComponent<Image>().enabled = false;
        player.GetComponent<PlayerMovement>().isMoveable = true;
        isDetail = false;
    }
}