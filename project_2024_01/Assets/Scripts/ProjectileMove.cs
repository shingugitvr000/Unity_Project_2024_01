using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour         //총알 클래스 설정
{
    public float lifeTime = 10.0f;              //총알 생성 후 살아있을 시간 ex) 10초 
    public float moveSpeed = 20.0f;             //총알 속도 설정
    public int damage = 1;                      //기초 데미지 설정

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENEMY")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<EnemyController>().currentHP -= damage;

            if(other.gameObject.GetComponent<EnemyController>().currentHP <= 0)
            {
                Destroy(other.gameObject);
            }
        }
        Debug.Log("TRIGGER ENTER : " + other.gameObject.name);        
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  //총알이 Z축 앞방향으로 이동하게 

        lifeTime -= Time.deltaTime;                                         //초를 설정하여 시간 확인
        if (lifeTime < 0.0f)
        {
            Destroy(this.gameObject);                                       //오브젝트 파괴
        }
    }
}
