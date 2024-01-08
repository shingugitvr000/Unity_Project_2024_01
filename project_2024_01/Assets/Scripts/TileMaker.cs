using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour
{
    public GameObject tile;             //게임 오브젝트 타일 선언
    
    void Start()
    {
        for(int i = 0; i < 10; i++) 
        {
            for(int j = 0; j < 10; j++) //Vector3 (0 ~ 9, 0.0f , 0 ~ 9) 100개 타일 생성
            {
                Instantiate(tile, new Vector3(i,0.0f,j), Quaternion.identity);  //타일을 생성하는 함수
            }
        }
    }   
    void Update()
    {
        
    }
}
