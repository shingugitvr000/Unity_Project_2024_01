using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;                 //간단한 싱글톤 화

    public Slider silderUI_Player_Hp_Bar;           //HP 슬라이더
    public Slider silderUI_Player_Exp_Bar;          //EXP 슬라이더
    public TMP_Text tmptextUI_Player_Hp;            //HP 표시
    public TMP_Text tmptextUI_Player_Exp;           //EXP 표시
    public TMP_Text tmptextUI_Player_Level;

    public GameObject levelUpPanel;                 //LevelUp 패널을 관리
    private void Awake()
    {
        Instance = this;
    }
    public void levelUpPanel_OnOff(bool temp)           //LevelUp 패널 OnOff 함수 제작 
    {
        levelUpPanel.SetActive(temp);
    }

    void Update()
    {
        tmptextUI_Player_Hp.text = GameManager.Instance.currentHp.ToString();
        tmptextUI_Player_Exp.text = GameManager.Instance.currentExp.ToString();
        tmptextUI_Player_Level.text = "LEVEL : " + GameManager.Instance.level.ToString();

        silderUI_Player_Hp_Bar.value = (float)GameManager.Instance.currentHp/(float)GameManager.Instance.maxHp;
        silderUI_Player_Exp_Bar.value = (float)GameManager.Instance.currentExp / 
            (float)GameManager.Instance.levelUpExp[GameManager.Instance.level - 1];     //Level 은 1부터 시작하기 때문에 -1를 해준다.

    }

}
