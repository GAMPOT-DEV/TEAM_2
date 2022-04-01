using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isFloat;
    public Image itemImage;
    public GameObject itemSlot;
    public GameObject item;
    void Start()
    {
        isFloat = false;
        itemSlot = transform.GetChild(0).gameObject;
        itemImage = itemSlot.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFloat)
        {
            FloatItem();
        }
    }

    void FloatItem()
    {
        itemSlot.SetActive(true);
    }
}