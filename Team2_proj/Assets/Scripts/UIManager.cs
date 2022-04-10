using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject ReportPanel;
    public GameObject MedicinePanel;
    public GameObject PianoPanel;
    public GameObject RealPanel;
    public GameObject Inventory;
    public GameObject Quiz8;
    GameObject PianoObject;
    GameObject LockObject;
    GameObject Phone;
    Piano PianoScript = null;
    Lock LockScript = null;

    public Camera playerCam;
    public GameObject rayObject;
    public GameObject player;

    Vector3 mousePos;

    void Start()
    {
        player = GameObject.Find("Player");
        Phone = GameObject.Find("phone");
        PianoObject = GameObject.Find("xylophone");

        if(PianoObject != null)
            PianoScript = PianoObject.GetComponent<Piano>();
        LockObject = GameObject.Find("Lock");
        if(LockObject != null)
            LockScript = LockObject.GetComponent<Lock>();

        PausePanel.SetActive(false);
        ReportPanel.SetActive(false);
        MedicinePanel.SetActive(false);
        PianoPanel.SetActive(false);
        RealPanel.SetActive(false);
        rayObject = null;
    }

    void Update()
    {
        RayCast();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
                if (PausePanel.activeSelf)
                {
                    OnClickContinue();
                }
                else if (ReportPanel.activeSelf)
                {
                    CloseReport();
                }
                else if (MedicinePanel.activeSelf)
                {
                    CloseMedicine();
                }
                else if (PianoScript != null && PianoScript.PianoPanel.activeSelf)
                {
                    PianoScript.ExitGame(true);
                }
                else if (LockScript != null && LockScript.isShowed)
                {
                    LockScript.ExitGame(true);
                }
                else if (Inventory.GetComponentInChildren<Inventory>().isDetail)
                {
                    Inventory.GetComponentInChildren<Inventory>().ExitDetail();
                }
                else
                {
                    OpenPause();
                }
        }

        if(Phone != null && !RealPanel.activeSelf)
            if (Phone.GetComponent<Quiz6>().isSolve)
                OpenRealPanel();
    }

    public void OpenRealPanel()
    {
        RealPanel.SetActive(true);
    }

    public void OpenPause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        //Inventory.SetActive(false);
        OpenPanel(PausePanel);
    }

    public void OpenPanel(GameObject go)
    {
        PlayerMove(false);
        go.SetActive(true);
    }

    public void OnClickQuit()
    {
        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#else
        //        Application.Quit();
        //#endif
        SceneManager.LoadScene("MainScreen");
    }

    public void OnClickContinue()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PausePanel.SetActive(false);
        Inventory.SetActive(true);
        PlayerMove(true);
    }

    //playerMovement로부터 가져오는 방향으로 바꿀 것
    void RayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 3))
        {
            rayObject = hit.collider.gameObject;

            if(rayObject.name == "report" && Input.GetMouseButtonDown(0))
            {
                ReportPanel.SetActive(true);
            }

            if(rayObject.name == "prescription")
            {
                MedicinePanel.SetActive(true);
            }
        }
        else
        {
            rayObject = null;
        }
    }

    public void CloseReport()
    {
        ReportPanel.SetActive(false);
        PlayerMove(true);
    }

    public void CloseMedicine()
    {
        MedicinePanel.SetActive(false);
        PlayerMove(true);
    }

    public void ReturnToReal()
    {
        //SceneManager.LoadScene("RealityRoom");
        Quiz8.SetActive(true);
    }

    public void NoReturnToReal()
    {
        SceneManager.LoadScene("FantasyRoom");
    }

    void PlayerMove(bool b)
    {
        player.GetComponent<PlayerMovement>().isMoveable = b;
    }
}