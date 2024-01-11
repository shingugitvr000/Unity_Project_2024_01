using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;                 //간단한 싱글톤 화

    public enum GAMESTATION : int
    {
        READY,
        PLAY = 10,
        STOP,
        LEVELUPUI = 20,
        OPTIONUI,
        END = 30
    }

    //플레이어 데이터     
    public int currentHp = 100;
    public int level = 1;
    public int[] levelUpExp = new int[30];                //30레벨 까지 설정 
    public int currentExp = 0;

    //플레이어 업그레이드 요소
    public int maxHp = 100;
    public float moveSpeed = 10.0f;
    public float fireSpeed = 4.0f;
    public int playerPower = 1;

    public GAMESTATION gameStation = GAMESTATION.READY;

    private void Awake()
    {
        Instance = this;
    }

    public void HpLevelUp()
    {
        maxHp += 10;
        GameUIManager.Instance.levelUpPanel_OnOff(false);
        gameStation = GAMESTATION.PLAY;
    }
    public void moveSpeedLevelUp()
    {
        moveSpeed += 0.1f;
        GameUIManager.Instance.levelUpPanel_OnOff(false);
        gameStation = GAMESTATION.PLAY;
    }
    public void fireSpeedLevelUp()
    {
        fireSpeed += 0.5f;
        GameUIManager.Instance.levelUpPanel_OnOff(false);
        gameStation = GAMESTATION.PLAY;
    }
    public void PowerLevelUp()
    {
        playerPower += 1;
        GameUIManager.Instance.levelUpPanel_OnOff(false);
        gameStation = GAMESTATION.PLAY;
    }


    public void Start()
    {
        GameUIManager.Instance.levelUpPanel_OnOff(false);       //시작시 LevelUp 패널을 Off 시킨다.
    }

    public void GamePlay()                          //게임 플레이 상태로 전환
    {
        gameStation = GAMESTATION.PLAY;
    }
    public void GamePlayStop()                      //게임 멈춤 상태로 전환
    {
        gameStation = GAMESTATION.STOP;
    }
    public void GamePlayLevelUp()                   //게임 레벨 업 상태로 전환
    {
        gameStation = GAMESTATION.LEVELUPUI;
    }
    public void ExpUp(int amount)
    {
        if (level == levelUpExp.Length) return;     //최대 레벨에 도달 했을 경우 그냥 리턴 

        currentExp += amount;                       //경험치를 Up 시킨다.
        LevelUpCheck();                             //레벨 업 체크를 한다.
    }
    public void LevelUpCheck()                      //레벨 업 체크 함수
    {
        if(currentExp >= levelUpExp[level - 1])     //기존 경험치가 필요 경험치보다 클 경우
        {
            currentExp -= levelUpExp[level - 1];    //레벨업에 대한 경험치를 뺀 이후
            level += 1;                             //레벨 업을 시켜준다. 

            if(level >= levelUpExp.Length)          //최대 레벨 이상 안올라가게 막아줘서 에러를 피한다. 
            {
                level = levelUpExp.Length;
            }
            GameUIManager.Instance.levelUpPanel_OnOff(true);
            gameStation = GAMESTATION.LEVELUPUI;
        }
    }
    public void GameOver()
    {
        gameStation = GAMESTATION.END;
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()               //코루틴을 선언 
    {
        yield return new WaitForSeconds(2.0f);  //2초 이후에 해당 내용 동작 
        SceneManager.LoadScene("TitleScene");   //2초 이후에 타이틀 화면으로 이동
    }
}
