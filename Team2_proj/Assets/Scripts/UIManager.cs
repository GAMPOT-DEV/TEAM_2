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
            if (!(Inventory.GetComponentInChildren<Inventory>().isDetail))
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
                else
                {
                    OpenPause();
                }
            }
        }

        //if(Phone != null && !RealPanel.activeSelf)
        //    if (Phone.GetComponent<Quiz6>().isSolve)
        //        OpenRealPanel();
    }

    public void OpenRealPanel()
    {
        RealPanel.SetActive(true);
    }

    public void OpenPause()
    {
        Inventory.SetActive(false);
        OpenPanel(PausePanel);
    }

    public void OpenPanel(GameObject go)
    {
        PlayerMove(false);
        go.SetActive(true);
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnClickContinue()
    {
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
    }

    public void NoReturnToReal()
    {
        Debug.Log("처음으로 돌아간다.");
        //SceneManager.LoadScene("RealityRoom");
        //다 완성하고 Scene 복사하면 해금할 것
    }

    void PlayerMove(bool b)
    {
        player.GetComponent<PlayerMovement>().isMoveable = b;
    }
}