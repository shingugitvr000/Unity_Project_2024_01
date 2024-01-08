using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour         //�Ѿ� Ŭ���� ����
{
    public float lifeTime = 10.0f;              //�Ѿ� ���� �� ������� �ð� ex) 10�� 
    public float moveSpeed = 20.0f;             //�Ѿ� �ӵ� ����

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  //�Ѿ��� Z�� �չ������� �̵��ϰ� 

        lifeTime -= Time.deltaTime;                                         //�ʸ� �����Ͽ� �ð� Ȯ��
        if (lifeTime < 0.0f)
        {
            Destroy(this.gameObject);                                       //������Ʈ �ı�
        }
    }
}
