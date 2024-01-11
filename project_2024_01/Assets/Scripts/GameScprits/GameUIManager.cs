using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager Instance;                 //������ �̱��� ȭ

    public Slider silderUI_Player_Hp_Bar;           //HP �����̴�
    public Slider silderUI_Player_Exp_Bar;          //EXP �����̴�   
    public TMP_Text tmptextUI_Player_Level;

    //Panel���� �� �� �ִ� ���� ��
    public TMP_Text tmptextUI_Player_Hp;            //HP ǥ��
    public TMP_Text tmptextUI_Player_Exp;           //EXP ǥ��
    public TMP_Text tmptextUI_Player_MoveSpeed;
    public TMP_Text tmptextUI_Player_FireSpeed;
    public TMP_Text tmptextUI_Player_Power;

    public GameObject levelUpPanel;                 //LevelUp �г��� ����
    public GameObject gameUIPanel;
    public bool gameUIOnoffFlag;                    //�г� Ű�� ���� Bool
    private void Awake()
    {
        Instance = this;
    }
    public void levelUpPanel_OnOff(bool temp)           //LevelUp �г� OnOff �Լ� ���� 
    {
        levelUpPanel.SetActive(temp);
    }

    void Update()
    {
        tmptextUI_Player_Hp.text = "HP : " + GameManager.Instance.currentHp.ToString();
        tmptextUI_Player_Exp.text = "EXP : " + GameManager.Instance.currentExp.ToString();
        tmptextUI_Player_MoveSpeed.text = "MoveSpeed : " + GameManager.Instance.moveSpeed.ToString();
        tmptextUI_Player_FireSpeed.text = "FireSpeed : " + GameManager.Instance.fireSpeed.ToString();
        tmptextUI_Player_Power.text = "Power : " + GameManager.Instance.playerPower.ToString();

        tmptextUI_Player_Level.text = "LEVEL : " + GameManager.Instance.level.ToString();

        silderUI_Player_Hp_Bar.value = (float)GameManager.Instance.currentHp/(float)GameManager.Instance.maxHp;
        silderUI_Player_Exp_Bar.value = (float)GameManager.Instance.currentExp / 
            (float)GameManager.Instance.levelUpExp[GameManager.Instance.level - 1];     //Level �� 1���� �����ϱ� ������ -1�� ���ش�.

        if(Input.GetKeyDown(KeyCode.Escape))            //ESC�� �������� ��� �Ѵ�. 
        {
            GameStopPanelOnOff();
        }

    }
    public void GameStopPanelOnOff()
    {
        if(gameUIOnoffFlag == true)                     //False <-> true �ٲ�� ���Ű�� ���� 
        {
            gameUIOnoffFlag = false;
            GameManager.Instance.gameStation = GameManager.GAMESTATION.PLAY;        //������ ���¸� �ٲ��ش�. 
        }
        else
        {
            gameUIOnoffFlag = true;
            GameManager.Instance.gameStation = GameManager.GAMESTATION.STOP;        //������ ���¸� �ٲ��ش�. 
        }

        gameUIPanel.SetActive(gameUIOnoffFlag);
    }

}
