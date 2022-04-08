using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject eyes;
    public GameObject sceneChange;
    GameManager manager;
    private bool isAnimStart;
    private bool isPlaying;

    private void Start() 
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isAnimStart = false;
        isPlaying = false;
    }
    
    private void Update() {
        //단 한번만 실행을 위해 isAnimStart 사용
        if((manager.puzzleIndex["Pill Bound"]==1)&&!isAnimStart)
        {
            eyes.SetActive(true);
            Animator myAnim = eyes.GetComponent<Animator>();
            WaitForAnimEnd(myAnim);
        }
    }

    void WaitForAnimEnd(Animator anim)
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)&&!isPlaying)
        {
            isAnimStart = true;
            isPlaying = true;
            eyes.SetActive(false);
            sceneChange.SetActive(true);
        }
    }
}
