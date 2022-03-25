using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    public int chainNum;

    private float chainRot;
    private int playerNum;

    private void Start()
    {
        playerNum = 1;
    }

    void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 40));
        
        if(playerNum<9)
        {
            playerNum++;
        }

        else
        {
            playerNum = 1;
        }

        //부모에게 chainNum, playerNum 전달
        transform.GetComponentInParent<Lock>().TestLock(chainNum, playerNum);
    }



}
