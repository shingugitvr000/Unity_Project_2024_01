using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 8.0f;          //이동 속도
    public float rotationSpeed = 1.0f;      //포탑 회전 속도
    public GameObject projectile;           //총알 프리팹 
    public GameObject Pivot;
    public Transform firePoint;             //총알 발사 위치
    public float fireRate = 1.0f;           //총알 발사 속도 

    private Rigidbody body;
    private Transform player;
    private float nextFireTime;

    public int maxHp;
    public int currentHP;

    public GameObject[] dropitems = new GameObject[2];

    public void DropItems()
    {
        int RandNumer = Random.Range(0, 100);       // 0 ~ 99의 랜덤 값을 리턴 

        if(RandNumer >= 0 && RandNumer < 50)        // 0 ~ 50 이전까지 50% 확률로 1번째 아이템 드랍
        {
            GameObject temp = (GameObject)Instantiate(dropitems[0], transform.position, Quaternion.identity);            
        }
        else if (RandNumer >= 50 && RandNumer < 70)  // 50 ~ 70 이전까지 20% 확률로 2번째 아이템 드랍
        {
            GameObject temp = (GameObject)Instantiate(dropitems[1], transform.position, Quaternion.identity);
        }
        else
        {
            //이 외에는 따로 행동 없음 
        }

    }

    void Start()
    {
        body = GetComponent<Rigidbody>();       //지금 오브젝트의 RigidBody를 가져옴
        player = GameObject.FindGameObjectWithTag("Player").transform;      //Player Tag를 가지고 있는 오브젝트 tranform을 입력
    }
    void Update()
    {
        if (GameManager.Instance.gameStation != GAMESTATION.PLAY) return;

        if(player != null)      //Player 가 있을때 만 업데이트 문을 사용해서 동작
        {
            if (Vector3.Distance(player.position, transform.position) > 5.0f) //Vector3.Distance 유니티에서 제공하는 거리 계산 함수 
            {
                Vector3 direction = (player.position - transform.position).normalized; //이동 방향성 (플레이어와 이 오브젝트(적))
                body.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime); //방향성 계산된것을 반영
            }
            //포탑 회전 소스 코드 
            Vector3 targetDirection = (player.position - Pivot.transform.position).normalized;  //포탑의 방향성 계산
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            //계산된 회전값을 반영
            Pivot.transform.rotation = Quaternion.Lerp(Pivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 

            //총알 발사

            if(Time.time > nextFireTime) 
            {
                nextFireTime = Time.time + 1f / fireRate;       //시간대비 쏘는 횟수 
                GameObject temp = (GameObject)Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
                temp.GetComponent<ProjectileMove>().projectileType = ProjectileMove.PROJECTILETYPE.ENEMY;   //발사체에 적이 쏜 총알이라고 이름을 만들어줌
            }
        }
    }
}
