using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            if(GameObject.Find("GameManager").GetComponent<GameManager>().puzzleIndex["Lock"] == 1)
            {
                EndGame();
            }
           
        }
        
    }

    void EndGame()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float deltaTime = 0f;

        GameObject panel = GameObject.Find("Canvas/EndingFadeOut");
        Color panelColor = panel.GetComponent<Image>().color;


        while (deltaTime <= 2.0f)
        {
            deltaTime += 0.02f;
            panelColor.a += 0.01f;
            panel.GetComponent<Image>().color = panelColor;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("EndingScene");
    }
}
