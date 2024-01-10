using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ProjectileMove : MonoBehaviour         //총알 클래스 설정
{
    public enum PROJECTILETYPE : int                //ENUM 값으로 총알을 누가 쐈는지 설정
    {
        PLAYER,
        ENEMY,
    }

    public float lifeTime = 10.0f;              //총알 생성 후 살아있을 시간 ex) 10초 
    public float moveSpeed = 20.0f;             //총알 속도 설정
    public int damage = 1;                      //기초 데미지 설정

    public GameObject VFX_Fire_B;
    public GameObject VFX_WW_Explosion;

    public PROJECTILETYPE projectileType = PROJECTILETYPE.PLAYER;        //디폴트는 플레이어 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ENEMY" && projectileType == PROJECTILETYPE.PLAYER)     //Tag 값이 Enemy이고 플레이어가 쐈을때
        {
            Destroy(this.gameObject);

            Vector3 point = other.ClosestPoint(transform.position);     //충돌이 일어난 포인트 
            GameObject tempVFX = (GameObject)Instantiate(VFX_Fire_B, point ,Quaternion.identity);   //충돌이 일어난 포인트에 이펙트 추가

            other.gameObject.GetComponent<EnemyController>().currentHP -= GameManager.Instance.playerPower;

            if(other.gameObject.GetComponent<EnemyController>().currentHP <= 0)
            {
                Instantiate(VFX_WW_Explosion, point, Quaternion.identity);   //적군이 파괴되는 포인트에 이펙트 추가
                other.gameObject.GetComponent<EnemyController>().DropItems();   //적군이 파괴되기 이전에 드랍 아이템 추가 
                Destroy(other.gameObject);               
            }
        }

        if (other.gameObject.tag == "Player" && projectileType == PROJECTILETYPE.ENEMY)     //Tag 값이 Enemy이고 플레이어가 쐈을때
        {
            Destroy(this.gameObject);
            Vector3 point = other.ClosestPoint(transform.position);     //충돌이 일어난 포인트 
            GameObject tempVFX = (GameObject)Instantiate(VFX_Fire_B, point, Quaternion.identity);   //충돌이 일어난 포인트에 이펙트 추가

            GameManager.Instance.currentHp -= damage;

            if (GameManager.Instance.currentHp <= 0)
            {
                Instantiate(VFX_WW_Explosion, point, Quaternion.identity);   //플레이어가 파괴 되는 이펙트를 준다. 
                Destroy(other.gameObject);
            }
        }

    }
    
    void Update()
    {
        if (GameManager.Instance.gameStation != GAMESTATION.PLAY) return;

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);  //총알이 Z축 앞방향으로 이동하게 

        lifeTime -= Time.deltaTime;                                         //초를 설정하여 시간 확인
        if (lifeTime < 0.0f)
        {
            Destroy(this.gameObject);                                       //오브젝트 파괴
        }
    }
}
