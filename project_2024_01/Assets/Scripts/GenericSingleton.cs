using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;              //���ʸ��� �ν��Ͻ� ���� 

    public static T Instance
    {
        get
        {
            if(_instance == null)                       //�ν��Ͻ��� ���� ���
            {
                _instance = FindObjectOfType<T>();        //TŬ������ ������Ʈ Ÿ������ ã��
                if(_instance == null)                     //NUll ���� ���
                {
                    GameObject obj = new GameObject();    //���� ������Ʈ�� ������ ��
                    obj.name = typeof(T).Name;            //������Ʈ �̸� ���� ��
                    _instance = obj.AddComponent<T>();    //Component class�� ���δ�. 
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()     //virtual ���� �Լ��� Awake
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
