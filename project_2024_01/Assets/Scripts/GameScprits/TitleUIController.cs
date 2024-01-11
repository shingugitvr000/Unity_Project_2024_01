using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIController : MonoBehaviour
{
    public Button btnStart;                 //��ư ��ŸƮ ����
    public Button btnOption;
    public Button btnEnd;
    // Start is called before the first frame update
    void Start()
    {
        btnStart.onClick.AddListener(OnClickBtnStart);      //��ư ���� ���� �����ʷ� �Լ� ���� 
        //btnStart.onClick.AddListener(delegate { OnClickBtnStart(0); }); //���� �Լ� �μ��� �������        
        btnOption.onClick.AddListener(OnClickBtnOption);
        btnEnd.onClick.AddListener(OnClickBtnEnd);
    }    
    void OnClickBtnStart()
    {
        AudioManager.instance.PlaySFX("Button_Down");
        SceneManager.LoadScene("PlayScene");
    }
    void OnClickBtnOption()
    {
        AudioManager.instance.PlaySFX("Button_Down");
        AudioManager.instance.PanelOnOff(true);
    }
    void OnClickBtnEnd()
    {
        AudioManager.instance.PlaySFX("Button_Down");
        Application.Quit();         //���� ���Ŀ� ��ư�� ������ ������ ����
    }
}
