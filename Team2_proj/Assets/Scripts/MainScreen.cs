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
        GameObject img = GameObject.Find("Canvas/MainScreen/Button/Image");
        GameObject title = GameObject.Find("Canvas/MainScreen/Title_name");

        Color panelColor = panel.GetComponent<Image>().color;
        Color imgColor = img.GetComponent<Image>().color;
        Color titleColor = title.GetComponent<Image>().color;


        while (deltaTime<=2.0f)
        {
            deltaTime += 0.02f;
            panelColor.a += 0.01f;
            imgColor.a -= 0.01f;
            titleColor.a -= 0.01f;

            panel.GetComponent<Image>().color = panelColor;
            img.GetComponent<Image>().color = imgColor;
            title.GetComponent<Image>().color = titleColor;

            yield return new WaitForSeconds(0.02f);
        }
        SceneManager.LoadScene("FantasyRoom");
    }
}
