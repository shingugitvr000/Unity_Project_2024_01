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

    public bool btnflag = false;
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
        if (btnflag == true) return;

        btnflag = true;
        StartCoroutine(btnStartRotine());           //�ڷ�ƾ�� ���� ���� ���� Scene�� �Ѿ�� �Ѵ�. 
    }

    IEnumerator btnStartRotine()
    {
        TransitionController.instance.FadeInOut();          //���̵� �ξƿ� ����
        yield return new WaitForSeconds(1.0f);              //1�� �� ���� ��ٸ���.
        SceneManager.LoadScene("PlayScene");                //�ʸ� ��ٸ� ���Ŀ� Scene �ε带 �Ѵ�. 
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
