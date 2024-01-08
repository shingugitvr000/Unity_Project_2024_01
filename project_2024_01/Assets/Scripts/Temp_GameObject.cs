using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_GameObject : MonoBehaviour
{
    public int hp = 30;                      //HP ���� int ���� 
    public float moveSpeed = 1.0f;           //�̵� ����Ʈ ����
    public Vector3 pos = Vector3.zero;       //Vector3 ���� ���� float

    void Start()
    {
        hp = 50;                            //HP ���۽� 50���� ���� 
        pos = new Vector3 (0.0f, -5.0f, 0.0f);
        transform.position = pos;
    }  
    void Update()
    {
        MoveCube();                                 //MoveCube �Լ� ��� 

        if (Input.GetKeyDown(KeyCode.Space))     //GetKeyDownŰ �� �Լ� ����(Ű�� ����������)
        {
            moveSpeed += 1;                       //�����̽� ������ �ӵ��� ������ 
        }     
    }
    public void MoveCube()              //Cube �̵��� ���� �Լ� ����                    
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.position += move * Time.deltaTime * moveSpeed;

        //if (Input.GetKey(KeyCode.UpArrow))
        //{   //Vector3(X,Y,Z)
        //    transform.position += new Vector3(0.0f, moveSpeed * Time.deltaTime, 0.0f);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += new Vector3(0.0f, -moveSpeed * Time.deltaTime, 0.0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
        //}
    }
}
