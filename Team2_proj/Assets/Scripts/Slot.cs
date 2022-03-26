using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool isFloat;
    public Image itemImage;
    GameObject Item;
    void Start()
    {
        isFloat = false;
        Item = transform.GetChild(0).gameObject;
        itemImage = Item.GetComponent<Image>();
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
        Item.SetActive(true);
    }
}
