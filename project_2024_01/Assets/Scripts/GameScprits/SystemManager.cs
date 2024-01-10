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

    public ROUNDTYPE roundtype = ROUNDTYPE.NORMAL;      //���� Ÿ���� ����

    public int roundindex = 1;                  //���� ����
    public float roundTime = 0.0f;              //���� �ð� Ÿ��
    public float roundEndTime = 30.0f;          //���� �� �ð�

    public float spawnTime = 0.0f;              //���� �ð� 
    public float nextspawnTime = 2.0f;          //���� ���� �ð� ����

    public GameObject[] EnemyBossObjects;       //���� ������Ʈ
    public GameObject[] EnemyObjects;           //�� ������Ʈ �迭
    public Transform[] spawntransform;          //���� ��ġ ������Ʈ �迭

    public GameObject EnemyBossCheck;           //���� üũ��

    public GameObject player;                   //�÷��̾� üũ��

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStation != GAMESTATION.PLAY) return;

        if (player != null)
        {

            if(roundtype == ROUNDTYPE.NORMAL)       //�븻Type �� ���¿����� �ð��� �������� ��
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
               
                int SpawntransformCount = spawntransform.Length;        //����� ���� ����Ʈ�� ������ �����´�.              
                int RandSpawntransformNumer = Random.Range(0, SpawntransformCount); //������ ���ڸ� �ִ�� ���� ���� ���ڸ� ���� 

                GameObject temp = (GameObject)Instantiate(
                    EnemyBossObjects[roundindex - 1], spawntransform[RandSpawntransformNumer].position, Quaternion.identity);
                EnemyBossCheck = temp;                          //���� üũ������   
                roundTime = 0.0f;                               //�ð� �ʱ�ȭ
                roundtype = ROUNDTYPE.BOSS;                     //���� Ÿ������ ����
            }

            if (nextspawnTime <= spawnTime)
            {
                spawnTime = 0.0f;
                nextspawnTime = Random.Range(0.5f, 2.0f);   //�������� ���� ���� �ð��� �����Ѵ�. 

                int EnemyObjectsCount = EnemyObjects.Length;            //����� �� ��ü�� ���ڸ� �����´�.
                int SpawntransformCount = spawntransform.Length;        //����� ���� ����Ʈ�� ������ �����´�.

                int RandEnemyObjectNumer = Random.Range(0, EnemyObjectsCount);      //������ ���ڸ� �ִ�� ���� ���� ���ڸ� ���� 
                int RandSpawntransformNumer = Random.Range(0, SpawntransformCount); //������ ���ڸ� �ִ�� ���� ���� ���ڸ� ���� 

                //�ش� ���� ���ڸ� ������� ��ϵ� ���� �迭 ��ȣ�� ���� ����Ʈ ��ȣ�� ��ġ�� ���� ���� ��Ų��. 
                GameObject temp = (GameObject)Instantiate(
                    EnemyObjects[RandEnemyObjectNumer] , spawntransform[RandSpawntransformNumer].position , Quaternion.identity);

            }


            if (player.transform.position.y < -50.0f)        //position �� y ���� ��ȸ�� ���� ���� �Է� �Ұ� (Vector3�θ� ������ �Է� ����)
            {
                player.transform.position = Vector3.zero + new Vector3(0.0f, 1.0f, 0.0f);   //Vector3.zero => new Vector3(0.0f,0.0f,0.0f)
                player.transform.rotation = Quaternion.identity;    //Quaternion.identity => new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
    }
}
