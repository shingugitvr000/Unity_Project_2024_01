using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_GameObject : MonoBehaviour
{
    public int hp = 30;                      //HP 변수 int 선언 
    void Start()
    {
        hp = 50;                            //HP 시작시 50으로 설정 
    }  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //GetKeyDown키 값 함수 설정
        {
            hp -= 1;                        //hp = hp - 1;
        }
    }
}
