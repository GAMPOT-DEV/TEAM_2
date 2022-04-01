using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public Camera playerCam;
    public PhysicMaterial PlayerFriction;
    public Transform theDest;
    public GameObject rayObject;
    public bool isMoveable;

    float MoveSpeed;
    float rotSpeed;
    float currentRot;
    float jumpPower;
    bool isJumping;
    

    void Start()
    {
        MoveSpeed = 4.0f;
        rotSpeed = 3.0f;
        currentRot = 0f;
        jumpPower = 5.0f;
        isJumping = false;
        rayObject = null;
        isMoveable = true;
    }

    private void FixedUpdate()
    {
        if(isMoveable)
        {
            PlayerMove();
        }
        
    }

    void Update()
    {
        if(isMoveable)
        {
            Jump();
            RotCtrl();
            RayCast();
        }

    }

    void PlayerMove()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * MoveSpeed;
        float zSpeed = zInput * MoveSpeed;

        transform.Translate(Vector3.forward * zSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJumping != true)
            {
                isJumping = true;
                playerRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                PlayerFriction.dynamicFriction = 0;
                PlayerFriction.staticFriction = 0;
            }
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isJumping = false;
            PlayerFriction.dynamicFriction = 0.6f;
            PlayerFriction.staticFriction = 0.6f;
        }
    }

    void RotCtrl()
    {
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis("Mouse X") * rotSpeed;

        // 마우스 반전
        currentRot -= rotX;

        // 마우스가 특정 각도를 넘어가지 않게 예외처리
        currentRot = Mathf.Clamp(currentRot, -80f, 80f);

        // Camera는 Player의 자식이므로 플레이어의 Y축 회전은 Camera에게도 똑같이 적용됨
        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        // Camera의 transform 컴포넌트의 로컬로테이션의 오일러각에 
        // 현재X축 로테이션을 나타내는 오일러각을 할당해준다.
        playerCam.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }

    void RayCast()
    {
        //crosshair가 가리키고 있는 object
        RaycastHit hit;

        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * 8, Color.red);

        //raycast에 오브젝트가 충돌했을때
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 3))
        {
            rayObject = hit.collider.gameObject;

            //오브젝트가 잡을 수 있는 tag라면 isGrabing이 참이고 highlight함수가 호출됨
            if (rayObject.tag == "Grabable")
            {
                rayObject.GetComponent<grabObject>().isGrabable = true;

                if (Input.GetMouseButtonDown(0))
                {
                    //grabObject.cs에서 
                    rayObject.GetComponent<grabObject>().isGrabing = true;
                    
                }
            }

            //퍼즐별 수행할 함수
            else if(rayObject.tag == "Puzzle")
            {

                //틀린그림찾기
                if (rayObject.name == "picture")
                {
                    //월드 좌표를 로컬 좌표로 변환
                    if (Physics.Raycast(transform.position, -Vector3.up, 100))
                    {
                        Vector3 v3LocalPoint = hit.transform.InverseTransformPoint(hit.point);
                        //Debug.Log(hit.point.y);
                        rayObject.GetComponentInParent<FindWrongPicture>().isFocus = true;
                        rayObject.GetComponentInParent<FindWrongPicture>().localPoint = v3LocalPoint;
                    }
            
                }

                //실로폰
                else if(rayObject.name == "xylophone")
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        rayObject.GetComponent<Piano>().isClicked = true;
                    }
                    
                }

                //자물쇠
                else if (rayObject.name == "Lock")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        rayObject.GetComponent<Lock>().isClicked = true;
                    }
                }

                //여기에 퍼즐을 추가로 쓰기

            }

            if(rayObject.name == "PillTest")
            {
                rayObject.GetComponent<PillQuiz>().BottleOnTable();
                Debug.Log("Pill Position Change & Pill Quiz Start!");
                //rayObject.GetComponent<PillQuiz>().PillQuizStart();
            }
            
            if(rayObject.name == "pill(Clone)")
            {
                Debug.Log("Pill");
                if (Input.GetMouseButtonDown(0))
                {
                    rayObject.GetComponent<Pill>().PillBreak();
                    Debug.Log("Pill Break");
                }
            }
    
        }
        else
        {
            rayObject = null;
        } 
    }
}