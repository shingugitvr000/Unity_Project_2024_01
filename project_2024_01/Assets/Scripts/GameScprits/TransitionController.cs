using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionController : MonoBehaviour
{
    public static TransitionController instance { get; private set; }         //static 사용하여 싱글톤 등록
    
    public Image blockBack;                                         //image UI를 가져온다.
    public float time = 1.0f;

    public bool flag = false;           //동작 중인지 검사하는 flag 
    public Sequence sequence;           //시퀀스 생성
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            FadeOut();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FadeIn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FadeInOut();
        }
    }
    public void FadeIn()
    {
        if (flag != false) return;

        sequence = DOTween.Sequence()
            .Append(blockBack.DOFade(0.0f, time));           

    }
    public void FadeOut()
    {
        if (flag != false) return;

        sequence = DOTween.Sequence()
            .Append(blockBack.DOFade(1.0f, time));   
    }

    public void FadeInOut()
    {
        if (flag != false) return;

        sequence = DOTween.Sequence()
            .Append(blockBack.DOFade(1.0f, time))
            .Append(blockBack.DOFade(0.0f, time));
    }


}
