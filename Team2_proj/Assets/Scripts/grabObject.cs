using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 코드는 인터렉트할 모든 오브젝트에게 붙여야 함.

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
