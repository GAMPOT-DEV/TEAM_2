using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class grabObject : MonoBehaviour
{
    public Transform theDest;

    private Rigidbody myRigid;
    private Collider myCollider;
    private MeshRenderer myRenderer;
    private float objDistance;
    private Transform playerPos;

    private bool isGrab;
    private bool isGrabable;



    void Start()
    {
        isGrab = false;
        playerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        isGrab = Input.GetMouseButton(0);
        distanceCulculate();
    }


    void OnMouseDown() //
    {
        if (isGrabable)
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

        if ((!isGrab) && (isGrabable))
        {
            myRenderer.material.color = new Color(1, 0, 0);
        }

        if (!isGrabable)
        {
            myRenderer.material.color = new Color(1, 1, 1);
        }


    }

    void OnMouseExit()
    {
        myRenderer.material.color = new Color(1, 1, 1);
    }


    void distanceCulculate()
    {
        Vector3 _objPos = transform.position;
        Vector3 _playerPos = playerPos.position;
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