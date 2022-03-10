using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera myCamera;
    public float rotSpeed;

    public float playerSpeed;
    private Rigidbody myRigid;
    private float currentRot;





    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CameraRotate();



    }

    void PlayerMove()
    {
        //캐릭터 무브먼트
        float _Xinput = Input.GetAxisRaw("Horizontal");
        float _Zinput = Input.GetAxisRaw("Vertical");

        float _Xvelocity = _Xinput * playerSpeed;
        float _Zvelocity = _Zinput * playerSpeed;

        transform.Translate(Vector3.right * _Xvelocity * Time.deltaTime);
        transform.Translate(Vector3.forward * _Zvelocity * Time.deltaTime);
    }

    void CameraRotate()
    {
        //카메라 회전
        float _rotX = Input.GetAxisRaw("Mouse Y") * rotSpeed;
        float _rotY = Input.GetAxisRaw("Mouse X") * rotSpeed;

        currentRot -= _rotX;
        currentRot = Mathf.Clamp(currentRot, -45f, 45f);

        this.transform.localRotation *= Quaternion.Euler(0, _rotY, 0f);
        myCamera.transform.localEulerAngles = new Vector3(currentRot, 0f, 0f);
    }
}
