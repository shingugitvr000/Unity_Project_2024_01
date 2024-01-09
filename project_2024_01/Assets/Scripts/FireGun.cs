using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    public float fireRate = 1.0f;           //�Ѿ� �߻� �ӵ� 
    private float nextFireTime;

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(0)) //���콺 ���� ��ư�� ������ ��
        //{//�Ѿ� �������� �����Ѵ�. ���� ��ġ�� firePoint�� ��ġ���� , ȸ������ �߽����� �����Ѵ�. 
        //    Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        //}

        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;       //�ð���� ��� Ƚ�� 
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
