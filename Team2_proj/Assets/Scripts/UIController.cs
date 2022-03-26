using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject PausePanel; //ESC ������ ������ Pause â
    public GameObject ReportPanel; //ó���� ������ Ȯ��Ǵ� â
    public GameObject MedicinePacketPanel; //����� ������ Ȯ��Ǵ� â
    public GameObject PianoPanel; //�Ƿ��� ������ ������ â
    
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
