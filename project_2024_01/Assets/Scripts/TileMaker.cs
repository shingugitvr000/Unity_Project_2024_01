using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour
{
    public GameObject tile;             //���� ������Ʈ Ÿ�� ����
    
    void Start()
    {
        for(int i = 0; i < 10; i++) 
        {
            for(int j = 0; j < 10; j++) //Vector3 (0 ~ 9, 0.0f , 0 ~ 9) 100�� Ÿ�� ����
            {
                Instantiate(tile, new Vector3(i,0.0f,j), Quaternion.identity);  //Ÿ���� �����ϴ� �Լ�
            }
        }
    }   
    void Update()
    {
        
    }
}
