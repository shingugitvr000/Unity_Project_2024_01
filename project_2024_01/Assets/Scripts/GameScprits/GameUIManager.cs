using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public Slider silderUI_Player_Hp_Bar;           //HP 슬라이더
    public Slider silderUI_Player_Exp_Bar;          //EXP 슬라이더
    public TMP_Text tmptextUI_Player_Hp;            //HP 표시
    public TMP_Text tmptextUI_Player_Exp;           //EXP 표시
    public TMP_Text tmptextUI_Player_Level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
