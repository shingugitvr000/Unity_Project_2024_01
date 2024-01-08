using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_GameObject : MonoBehaviour
{
    public int hp = 30;                      //HP 변수 int 선언 
    public Vector3 pos = Vector3.zero;       //Vector3 변수 선언 float

    void Start()
    {
        hp = 50;                            //HP 시작시 50으로 설정 
        pos = new Vector3 (0.0f, -5.0f, 0.0f);
        transform.position = pos;
    }  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //GetKeyDown키 값 함수 설정(키가 내려갔을때)
        {
            hp -= 1;                        //hp = hp - 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))     //GetKey키 값 함수 설정(키가 눌려져 있을때)
        {   //Time.deltaTime 프레임 사이 시간을 알려주는 변수 
            transform.position += new Vector3(0.0f, 1.0f * Time.deltaTime, 0.0f);
        }
    }
}
