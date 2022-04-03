using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void GameStartOnClick()
    {
        StartCoroutine(FadeOut());
        
    }

    IEnumerator FadeOut()
    {
        float deltaTime = 0f;

        GameObject panel = GameObject.Find("Canvas/MainScreen/Panel");
        Color panelColor = panel.GetComponent<Image>().color;


        while (deltaTime<=2.0f)
        {
            deltaTime += 0.02f;
            panelColor.a += 0.01f;
            panel.GetComponent<Image>().color = panelColor;
            yield return new WaitForSeconds(0.02f);
        }
        SceneManager.LoadScene("FantasyRoom");
    }
}
