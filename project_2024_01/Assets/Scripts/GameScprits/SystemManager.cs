using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.y < -50.0f)        //position 의 y 값을 조회는 가능 직접 입력 불가 (Vector3로만 데이터 입력 가능)
            {
                player.transform.position = Vector3.zero + new Vector3(0.0f, 1.0f, 0.0f);   //Vector3.zero => new Vector3(0.0f,0.0f,0.0f)
                player.transform.rotation = Quaternion.identity;    //Quaternion.identity => new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
    }
}
