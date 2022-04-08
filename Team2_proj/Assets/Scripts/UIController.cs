using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject PausePanel; //ESC 누르면 나오는 Pause 창
    public GameObject ReportPanel; //처방전 누르면 확대되는 창
    public GameObject MedicinePacketPanel; //약봉지 누르면 확대되는 창
    public GameObject PianoPanel; //실로폰 누르면 나오는 창
    
    void Start()
    {
        PausePanel.SetActive(false);
        ReportPanel.SetActive(false);
        MedicinePacketPanel.SetActive(false);
        PianoPanel.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
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
}