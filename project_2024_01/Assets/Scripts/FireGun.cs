using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //마우스 왼쪽 버튼을 눌렀을 때
        {//총알 프리팹을 생성한다. 생성 위치는 firePoint의 위치값과 , 회전값을 중심으로 생성한다. 
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
