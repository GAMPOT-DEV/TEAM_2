using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{


    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
