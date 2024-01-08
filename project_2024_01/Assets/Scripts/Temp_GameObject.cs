using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_GameObject : MonoBehaviour
{
    public int hp = 30;                      //HP ���� int ���� 
    public Vector3 pos = Vector3.zero;       //Vector3 ���� ���� float

    void Start()
    {
        hp = 50;                            //HP ���۽� 50���� ���� 
        pos = new Vector3 (0.0f, -5.0f, 0.0f);
        transform.position = pos;
    }  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //GetKeyDownŰ �� �Լ� ����(Ű�� ����������)
        {
            hp -= 1;                        //hp = hp - 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))     //GetKeyŰ �� �Լ� ����(Ű�� ������ ������)
        {   //Time.deltaTime ������ ���� �ð��� �˷��ִ� ���� 
            transform.position += new Vector3(0.0f, 1.0f * Time.deltaTime, 0.0f);
        }
    }
}
