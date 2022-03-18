using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabObject : MonoBehaviour
{
    public Transform theDest;

    public bool isGrabable; //playerMovement.cs 에서 raycast에 충돌했을 때 true
    public bool isGrabing; //playerMovement.cs 에서 raycast에 충돌했을 때 클릭 시 true
    public bool isPuzzle;
    public Rigidbody myRigid;
    public Collider myCollider;
    public MeshRenderer myRenderer;
    public Transform playerPos;
    




    void Start()
    {

        isGrabing = false;
        isGrabable = false;
        isPuzzle = false;
        playerPos = GameObject.FindWithTag("Player").transform;
        
    }

    void Update()
    {


        objSpin();
        RayCollide();
        HighlightObj();
    }   

    void objSpin()
    {
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(0,90,0,Space.Self);
        }
    }

    //오브젝트와 playerMovement의 rayCast가 충돌 시 호출
    public void RayCollide()
    {
        if(isGrabing)
        {
            isGrabing = Input.GetMouseButton(0);

            myRigid = GetComponent<Rigidbody>();
            myCollider = GetComponent<Collider>();

            myRigid.useGravity = false;
            myCollider.enabled = false;

            transform.position = theDest.position;
            transform.parent = GameObject.Find("The Dest").transform;
        }

        else
        {
            myRigid = GetComponent<Rigidbody>();
            myCollider = GetComponent<Collider>();

            myRigid.useGravity = true;
            myCollider.enabled = true;

            transform.parent = null;
        }

    }

    //오브젝트와 playerMovement의 rayCast가 충돌 시 호출
    public void HighlightObj()
    {
        isGrabable = IsInRay();
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = new Color(1, 1, 1);

        if(isGrabable)
        {
            myRenderer = GetComponent<MeshRenderer>();

            myRenderer.material.color = new Color(1, 0, 0);
        }
    }

    //raycast와 충돌한 오브젝트가 퍼즐일 경우 호출
    //퍼즐마다 meshrenderer가 다르기 때문에 추가로 함수를 만듦
    public void HighlightPuzzle(GameObject gameObj)
    {
        if(gameObj.name == "picture")
        {

        }

        else if(gameObj.name == "xylophone")
        {
            transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }

        //여기에 퍼즐 추가

    }

    public bool IsInRay()
    {
        if(isGrabing)
        {
            return false;
        }

        GameObject rayObj = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().rayObject;
        if(rayObj==null)
        {
            return false;
        }

        //PlayerMovement.cs에서 raycast에 충돌한 obj가 this.object일 경우 object가 highlight된다
        if(rayObj.name == this.name)
        {
            return true;
        }

        else
        {
            return false;


        }
    }



}
