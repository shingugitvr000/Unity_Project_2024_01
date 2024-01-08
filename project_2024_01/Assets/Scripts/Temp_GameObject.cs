using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_GameObject : MonoBehaviour
{
    public int hp = 30;                      //HP 변수 int 선언 
    public float moveSpeed = 1.0f;           //이동 스피트 설정
    public Vector3 pos = Vector3.zero;       //Vector3 변수 선언 float

    void Start()
    {
        hp = 50;                            //HP 시작시 50으로 설정 
        pos = new Vector3 (0.0f, -5.0f, 0.0f);
        transform.position = pos;
    }  
    void Update()
    {
        MoveCube();                                 //MoveCube 함수 사용 

        if (Input.GetKeyDown(KeyCode.Space))     //GetKeyDown키 값 함수 설정(키가 내려갔을때)
        {
            moveSpeed += 1;                       //스페이스 누를시 속도가 빨라짐 
        }     
    }
    public void MoveCube()              //Cube 이동을 위한 함수 선언                    
    {
        if (Input.GetKey(KeyCode.UpArrow))     
        {   //Vector3(X,Y,Z)
            transform.position += new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))    
        {  
            transform.position += new Vector3(0.0f, -moveSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))    
        { 
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))   
        {  
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        }
    }
}
