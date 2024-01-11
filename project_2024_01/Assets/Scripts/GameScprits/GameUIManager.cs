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
    public static GameUIManager Instance;                 //간단한 싱글톤 화

    public Slider silderUI_Player_Hp_Bar;           //HP 슬라이더
    public Slider silderUI_Player_Exp_Bar;          //EXP 슬라이더   
    public TMP_Text tmptextUI_Player_Level;

    //Panel에서 볼 수 있는 정보 값
    public TMP_Text tmptextUI_Player_Hp;            //HP 표시
    public TMP_Text tmptextUI_Player_Exp;           //EXP 표시
    public TMP_Text tmptextUI_Player_MoveSpeed;
    public TMP_Text tmptextUI_Player_FireSpeed;
    public TMP_Text tmptextUI_Player_Power;

    //3,2,1 연출 폰트
    public GameObject[] tmptext = new GameObject[3];


    public GameObject levelUpPanel;                 //LevelUp 패널을 관리
    public GameObject gameUIPanel;
    public bool gameUIOnoffFlag;                    //패널 키고 끄는 Bool
    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        StartCoroutine(StartRoutine());             //연출 코루틴 시작
    }
    IEnumerator StartRoutine()                          //연출 코루틴 제작
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
    public void tempTextOff()                   //연출을 위해 모든 폰트를 끄는 함수
    {
        for(int i = 0; i < 3; i++)
        {
            tmptext[i].SetActive(false);
        }
    }
    public void levelUpPanel_OnOff(bool temp)           //LevelUp 패널 OnOff 함수 제작 
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
            (float)GameManager.Instance.levelUpExp[GameManager.Instance.level - 1];     //Level 은 1부터 시작하기 때문에 -1를 해준다.

        if(Input.GetKeyDown(KeyCode.Escape))            //ESC를 눌렀을때 토글 한다. 
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
            GameManager.Instance.gameStation = GameManager.GAMESTATION.PLAY;        //게임의 상태를 바꿔준다. 
        }
        else if (GameManager.Instance.gameStation == GameManager.GAMESTATION.OPTIONUI && gameUIOnoffFlag == true)
        {
            gameUIOnoffFlag = false;
            AudioManager.instance.PanelOnOff(false);
            GameManager.Instance.gameStation = GameManager.GAMESTATION.STOP;
        }
        else if (GameManager.Instance.gameStation != GameManager.GAMESTATION.OPTIONUI && gameUIOnoffFlag == true
            && AudioManager.instance.AudioPanelFlag != false)                     //False <-> true 바뀌는 토글키로 생성 
        {
            gameUIOnoffFlag = false;
            GameManager.Instance.gameStation = GameManager.GAMESTATION.PLAY;        //게임의 상태를 바꿔준다. 
        }
        else
        {
            gameUIOnoffFlag = true;
            GameManager.Instance.gameStation = GameManager.GAMESTATION.STOP;        //게임의 상태를 바꿔준다. 
        }

        gameUIPanel.SetActive(gameUIOnoffFlag);
    }

    //패널 관련 함수 제작
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
    public void GameUITitlebtn()                //타이틀로 돌아가는 함수 
    {
        AudioManager.instance.PlaySFX("Button_Down");
        SceneManager.LoadScene("TitleScene");
    }

}
