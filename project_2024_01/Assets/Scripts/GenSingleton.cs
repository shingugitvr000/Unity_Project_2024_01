using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       //UI�� ����ϱ����ؼ� ����
using TMPro;

public class GenSingleton : GenericSingleton<GenSingleton>
{
    //public Text textUI;                             //���Ž� Text ����
    public TMP_Text tmptextUI;                      //TMP Text ����
    public int playerScore = 0;
    public int playerScoreMax = 100;
    public Slider mainSlider;
    public void AddScore(int amount)                //��ư Event �� ���� ��Ű�� ������ �ø���. 
    {
        playerScore += amount;
        tmptextUI.text = playerScore.ToString();        //Score �� int �̱� ������ ToString �� ���ڿ��� ��ȯ 
        mainSlider.value = (float)playerScore / (float)playerScoreMax;  //Slider�� ���� �ݿ��� �� 
    }

    public void SubmitSliderValue()                 //Slider���� ���� ������ ��
    {
        tmptextUI.text = mainSlider.value.ToString();
    }

    public void Start()
    {      
        tmptextUI.text = playerScore.ToString();
    }
}
