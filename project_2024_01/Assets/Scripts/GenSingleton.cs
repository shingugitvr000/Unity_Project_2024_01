using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                       //UI를 사용하기위해서 선언
using TMPro;

public class GenSingleton : GenericSingleton<GenSingleton>
{
    //public Text textUI;                             //레거시 Text 선언
    public TMP_Text tmptextUI;                      //TMP Text 선언
    public int playerScore = 0;
    public int playerScoreMax = 100;
    public Slider mainSlider;
    public void AddScore(int amount)                //버튼 Event 와 연결 시키고 점수를 올린다. 
    {
        playerScore += amount;
        tmptextUI.text = playerScore.ToString();        //Score 는 int 이기 때문에 ToString 로 문자열로 변환 
        mainSlider.value = (float)playerScore / (float)playerScoreMax;  //Slider에 값을 반영할 때 
    }

    public void SubmitSliderValue()                 //Slider에서 값을 가져올 때
    {
        tmptextUI.text = mainSlider.value.ToString();
    }

    public void Start()
    {      
        tmptextUI.text = playerScore.ToString();
    }
}
