using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Singleton.Instance.AddScore(10);                //싱글톤 클래스 Instance에 접근하여 함수 호출 
        GenSingleton.Instance.AddScore(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
