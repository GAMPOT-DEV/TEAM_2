using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� �ڵ�� ���ͷ�Ʈ�� ��� ������Ʈ���� �ٿ��� ��.

public class grabObject : MonoBehaviour
{
    
    public Transform theDest;

    private Rigidbody rigid;
    private Collider myCollider;

    void OnMouseDown()
    {
        rigid = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();

        rigid.useGravity = false;
        myCollider.enabled = false;
        
        transform.position = theDest.position;
        transform.parent = GameObject.Find("GrabDest").transform;
    }

    void OnMouseUp()
    {
        transform.parent = null;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = true;
        myCollider.enabled = true;
    }
}
