using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static GameManager;

public class SystemManager : MonoBehaviour
{
    public enum ROUNDTYPE : int
    {
        NORMAL,
        BOSS
    }

    public ROUNDTYPE roundtype = ROUNDTYPE.NORMAL;      //라운드 타입을 설정

    public int roundindex = 1;                  //라운드 순서
    public float roundTime = 0.0f;              //라운드 시간 타입
    public float roundEndTime = 30.0f;          //라운드 끝 시간

    public float spawnTime = 0.0f;              //스폰 시간 
    public float nextspawnTime = 2.0f;          //다음 스폰 시간 설정

    public GameObject[] EnemyBossObjects;       //보스 오브젝트
    public GameObject[] EnemyObjects;           //적 오브젝트 배열
    public Transform[] spawntransform;          //스폰 위치 오브젝트 배열

    public GameObject EnemyBossCheck;           //보스 체크용

    public GameObject player;                   //플레이어 체크용

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStation != GAMESTATION.PLAY) return;

        if (player != null)
        {

            if(roundtype == ROUNDTYPE.NORMAL)       //노말Type 인 상태에서만 시간이 지나가게 함
            {
                spawnTime += Time.deltaTime;
                roundTime += Time.deltaTime;
            }
            else if (roundtype == ROUNDTYPE.BOSS)
            {
                if(EnemyBossCheck == null)
                {
                    roundtype = ROUNDTYPE.NORMAL;
                    roundindex += 1;
                    if(EnemyBossObjects.Length < roundindex)
                    {
                        roundindex = EnemyBossObjects.Length;
                    }
                }
            }

            if (roundEndTime <= roundTime)
            {
               
                int SpawntransformCount = spawntransform.Length;        //등록한 스폰 포인트의 갯수를 가져온다.              
                int RandSpawntransformNumer = Random.Range(0, SpawntransformCount); //가져온 숫자를 최대로 놓고 랜덤 숫자를 생성 

                GameObject temp = (GameObject)Instantiate(
                    EnemyBossObjects[roundindex - 1], spawntransform[RandSpawntransformNumer].position, Quaternion.identity);
                EnemyBossCheck = temp;                          //보스 체크용으로   
                roundTime = 0.0f;                               //시간 초기화
                roundtype = ROUNDTYPE.BOSS;                     //보스 타입으로 변경
            }

            if (nextspawnTime <= spawnTime)
            {
                spawnTime = 0.0f;
                nextspawnTime = Random.Range(0.5f, 2.0f);   //랜덤으로 다음 스폰 시간을 설정한다. 

                int EnemyObjectsCount = EnemyObjects.Length;            //등록한 적 개체의 숫자를 가져온다.
                int SpawntransformCount = spawntransform.Length;        //등록한 스폰 포인트의 갯수를 가져온다.

                int RandEnemyObjectNumer = Random.Range(0, EnemyObjectsCount);      //가져온 숫자를 최대로 놓고 랜덤 숫자를 생성 
                int RandSpawntransformNumer = Random.Range(0, SpawntransformCount); //가져온 숫자를 최대로 놓고 랜덤 숫자를 생성 

                //해당 랜덤 숫자를 기반으로 등록된 몬스터 배열 번호와 스폰 포인트 번호에 위치에 적을 생성 시킨다. 
                GameObject temp = (GameObject)Instantiate(
                    EnemyObjects[RandEnemyObjectNumer] , spawntransform[RandSpawntransformNumer].position , Quaternion.identity);

            }


            if (player.transform.position.y < -50.0f)        //position 의 y 값을 조회는 가능 직접 입력 불가 (Vector3로만 데이터 입력 가능)
            {
                player.transform.position = Vector3.zero + new Vector3(0.0f, 1.0f, 0.0f);   //Vector3.zero => new Vector3(0.0f,0.0f,0.0f)
                player.transform.rotation = Quaternion.identity;    //Quaternion.identity => new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
    }
}
