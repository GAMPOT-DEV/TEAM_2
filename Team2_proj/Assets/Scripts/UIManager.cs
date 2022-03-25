using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject ReportPanel;
    public GameObject MedicinePanel;

    public Camera playerCam;
    public GameObject rayObject;

    void Start()
    {
        PausePanel.SetActive(false);
        ReportPanel.SetActive(false);
        MedicinePanel.SetActive(false);
        rayObject = null;
    }

    void Update()
    {
        OpenPause();
        RayCast();
    }

    public void OpenPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPanel(PausePanel);
        }
    }

    public void OpenPanel(GameObject go)
    {
        Time.timeScale = 0f;
        go.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            if (go == ReportPanel || go == MedicinePanel)
                go.SetActive(false);
        }
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
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    void RayCast()
    {
        //crosshair가 가리키고 있는 object
        RaycastHit hit;

        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * 8, Color.red);

        //raycast에 오브젝트가 충돌했을때
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 3))
        {
            rayObject = hit.collider.gameObject;
            Debug.Log(rayObject.name);

            if(rayObject.name == "report" && Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1f;
                ReportPanel.SetActive(true);

                

                //if(ReportPanel.activeSelf == true || Input.GetMouseButtonDown(0))
                    //ReportPanel.SetActive(false);
            }

            if(rayObject.name == "prescription") //처방전
            {
                Time.timeScale = 1f;
                MedicinePanel.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                    MedicinePanel.SetActive(false);
            }
        }
        else
        {
            rayObject = null;
        }
    }
}