using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIController : MonoBehaviour
{
    public Button btnStart;                 //버튼 스타트 선언
    public Button btnOption;
    public Button btnEnd;
    // Start is called before the first frame update
    void Start()
    {
        btnStart.onClick.AddListener(OnClickBtnStart);      //버튼 선언 이후 리스너로 함수 실행 
        //btnStart.onClick.AddListener(delegate { OnClickBtnStart(0); }); //만약 함수 인수가 있을경우        
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
        Application.Quit();         //빌드 이후에 버튼을 누르면 게임이 종료
    }
}
