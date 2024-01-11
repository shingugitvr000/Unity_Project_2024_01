using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionController : MonoBehaviour
{
    public static TransitionController instance { get; private set; }         //static ����Ͽ� �̱��� ���
    
    public Image blockBack;                                         //image UI�� �����´�.
    public float time = 1.0f;

    public bool flag = false;           //���� ������ �˻��ϴ� flag 
    public Sequence sequence;           //������ ����
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
