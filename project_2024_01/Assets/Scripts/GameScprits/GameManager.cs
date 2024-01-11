using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;                 //������ �̱��� ȭ

    public enum GAMESTATION : int
    {
        READY,
        PLAY = 10,
        STOP,
        LEVELUPUI = 20,
        OPTIONUI,
        END = 30
    }

    //�÷��̾� ������     
    public int currentHp = 100;
    public int level = 1;
    public int[] levelUpExp = new int[30];                //30���� ���� ���� 
    public int currentExp = 0;

    //�÷��̾� ���׷��̵� ���
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
        GameUIManager.Instance.levelUpPanel_OnOff(false);       //���۽� LevelUp �г��� Off ��Ų��.
    }

    public void GamePlay()                          //���� �÷��� ���·� ��ȯ
    {
        gameStation = GAMESTATION.PLAY;
    }
    public void GamePlayStop()                      //���� ���� ���·� ��ȯ
    {
        gameStation = GAMESTATION.STOP;
    }
    public void GamePlayLevelUp()                   //���� ���� �� ���·� ��ȯ
    {
        gameStation = GAMESTATION.LEVELUPUI;
    }
    public void ExpUp(int amount)
    {
        if (level == levelUpExp.Length) return;     //�ִ� ������ ���� ���� ��� �׳� ���� 

        currentExp += amount;                       //����ġ�� Up ��Ų��.
        LevelUpCheck();                             //���� �� üũ�� �Ѵ�.
    }
    public void LevelUpCheck()                      //���� �� üũ �Լ�
    {
        if(currentExp >= levelUpExp[level - 1])     //���� ����ġ�� �ʿ� ����ġ���� Ŭ ���
        {
            currentExp -= levelUpExp[level - 1];    //�������� ���� ����ġ�� �� ����
            level += 1;                             //���� ���� �����ش�. 

            if(level >= levelUpExp.Length)          //�ִ� ���� �̻� �ȿö󰡰� �����༭ ������ ���Ѵ�. 
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

    IEnumerator GameOverRoutine()               //�ڷ�ƾ�� ���� 
    {
        yield return new WaitForSeconds(2.0f);  //2�� ���Ŀ� �ش� ���� ���� 
        SceneManager.LoadScene("TitleScene");   //2�� ���Ŀ� Ÿ��Ʋ ȭ������ �̵�
    }
}
