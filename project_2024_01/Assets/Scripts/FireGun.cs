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
        if(Input.GetMouseButtonDown(0)) //���콺 ���� ��ư�� ������ ��
        {//�Ѿ� �������� �����Ѵ�. ���� ��ġ�� firePoint�� ��ġ���� , ȸ������ �߽����� �����Ѵ�. 
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
