using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using static GameManager;
using System.Xml;

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

    //3,2,1 ���� ��Ʈ
    public GameObject[] tmptext = new GameObject[3];


    public GameObject levelUpPanel;                 //LevelUp �г��� ����
    public GameObject gameUIPanel;
    public bool gameUIOnoffFlag;                    //�г� Ű�� ���� Bool
    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        StartCoroutine(StartRoutine());             //���� �ڷ�ƾ ����
    }
    IEnumerator StartRoutine()                          //���� �ڷ�ƾ ����
    {
        tempTextOff();
        tmptext[0].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        tempTextOff();
        tmptext[1].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        tempTextOff();
        tmptext[2].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        tempTextOff();
        GameManager.Instance.gameStation = GAMESTATION.PLAY;
    }
    public void tempTextOff()                   //������ ���� ��� ��Ʈ�� ���� �Լ�
    {
        for(int i = 0; i < 3; i++)
        {
            tmptext[i].SetActive(false);
        }
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
        if (AudioManager.instance.AudioPanelFlag == false && gameUIOnoffFlag == true
            && GameManager.Instance.gameStation == GameManager.GAMESTATION.OPTIONUI)
        {
            gameUIOnoffFlag = false;
            GameManager.Instance.gameStation = GameManager.GAMESTATION.PLAY;        //������ ���¸� �ٲ��ش�. 
        }
        else if (GameManager.Instance.gameStation == GameManager.GAMESTATION.OPTIONUI && gameUIOnoffFlag == true)
        {
            gameUIOnoffFlag = false;
            AudioManager.instance.PanelOnOff(false);
            GameManager.Instance.gameStation = GameManager.GAMESTATION.STOP;
        }
        else if (GameManager.Instance.gameStation != GameManager.GAMESTATION.OPTIONUI && gameUIOnoffFlag == true
            && AudioManager.instance.AudioPanelFlag != false)                     //False <-> true �ٲ�� ���Ű�� ���� 
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

    //�г� ���� �Լ� ����
    public void GameUIPlaybtn()                          
    {
        AudioManager.instance.PlaySFX("Button_Down");
        GameManager.Instance.gameStation = GameManager.GAMESTATION.PLAY;
        gameUIPanel.SetActive(false);
    }
    public void GameUIOptionbtn()
    {
        AudioManager.instance.PlaySFX("Button_Down");
        GameManager.Instance.gameStation = GameManager.GAMESTATION.OPTIONUI;
        AudioManager.instance.PanelOnOff(true);
    }
    public void GameUITitlebtn()                //Ÿ��Ʋ�� ���ư��� �Լ� 
    {
        AudioManager.instance.PlaySFX("Button_Down");
        SceneManager.LoadScene("TitleScene");
    }

}
