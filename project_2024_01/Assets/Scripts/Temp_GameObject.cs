using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_GameObject : MonoBehaviour
{
    public int hp = 30;                      //HP ���� int ���� 
    void Start()
    {
        hp = 50;                            //HP ���۽� 50���� ���� 
    }  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //GetKeyDownŰ �� �Լ� ����
        {
            hp -= 1;                        //hp = hp - 1;
        }
    }
}
