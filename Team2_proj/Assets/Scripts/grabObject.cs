using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 코드는 인터렉트할 모든 오브젝트에게 붙여야 함.

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
        //마우스를 클릭하고 있으면 오브젝트가 highlight되지 않음
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

        if ((!isGrab)&&(isGrabable)) //잡고 있을 때는 색 변경 X
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

   
    void distanceCulculate() //물제와 플레이어 사이의 거리를 측정 후 잡을 수 있는지 판단
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
