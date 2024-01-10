using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;              //제너릭한 인스턴스 생성 

    public static T Instance
    {
        get
        {
            if(_instance == null)                       //인스턴스가 없을 경우
            {
                _instance = FindObjectOfType<T>();        //T클래스를 오브젝트 타입으로 찾고
                if(_instance == null)                     //NUll 값인 경우
                {
                    GameObject obj = new GameObject();    //게임 오브젝트를 생성한 후
                    obj.name = typeof(T).Name;            //오브젝트 이름 설정 후
                    _instance = obj.AddComponent<T>();    //Component class를 붙인다. 
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()     //virtual 가상 함수로 Awake
    {
        if( _instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if( _instance != this ) 
        {
            Destroy(gameObject);
        }
    }
}
