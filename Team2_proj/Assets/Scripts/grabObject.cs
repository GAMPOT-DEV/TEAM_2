using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� �ڵ�� ���ͷ�Ʈ�� ��� ������Ʈ���� �ٿ��� ��.

public class grabObject : MonoBehaviour
{
    public Transform theDest;

    private Rigidbody myRigid;
    private Collider myCollider;
    private MeshRenderer myRenderer;
    private float objDistance;

    private bool isGrab;
    private bool isGrabable;
 


    void Start()
    {
        isGrab = false;
  
    }

    void Update()
    {
        //���콺�� Ŭ���ϰ� ������ ������Ʈ�� highlight���� ����
        isGrab = Input.GetMouseButton(0);
        distanceCulculate();
    }


    void OnMouseDown() //
    {
        if(isGrabable)
        {
            myRigid = GetComponent<Rigidbody>();
            myCollider = GetComponent<Collider>();


            myRigid.useGravity = false;
            myCollider.enabled = false;


            transform.position = theDest.position;
            transform.parent = GameObject.Find("GrabDest").transform;
        }
        

        
    }
    

    void OnMouseUp()
    {
        myRigid = GetComponent<Rigidbody>();

        myRigid.useGravity = true;
        myCollider.enabled = true;
        transform.parent = null;

        isGrab = false;
    }

    void OnMouseOver()
    {
        myRenderer = GetComponent<MeshRenderer>();

        if ((!isGrab)&&(isGrabable)) //��� ���� ���� �� ���� X
        {
            myRenderer.material.color = new Color(1, 0, 0);
        }

        if(!isGrabable)
        {
            myRenderer.material.color = new Color(1, 1, 1);
        }

        
    }

    void OnMouseExit()
    {
        myRenderer.material.color = new Color(1, 1, 1);
    }

   
    void distanceCulculate() //������ �÷��̾� ������ �Ÿ��� ���� �� ���� �� �ִ��� �Ǵ�
    {
        Vector3 _objPos = transform.position;
        Vector3 _playerPos = GameObject.Find("Player").GetComponent<PlayerMovement>().transform.position;
        objDistance = Vector3.Distance(_objPos, _playerPos);

        if (objDistance <= 3.0f)
        {
            isGrabable = true;
        }
        else
        {
            isGrabable = false;
        }

    }


}
