using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public void GameStartOnClick()
    {
        SceneManager.LoadScene("FantasyRoom");
    }
}
