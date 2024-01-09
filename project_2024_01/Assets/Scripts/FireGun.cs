using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    public float fireRate = 1.0f;           //총알 발사 속도 
    private float nextFireTime;

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0)) //마우스 왼쪽 버튼을 눌렀을 때
        //{//총알 프리팹을 생성한다. 생성 위치는 firePoint의 위치값과 , 회전값을 중심으로 생성한다. 
        //    Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        //}

        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;       //시간대비 쏘는 횟수 
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
