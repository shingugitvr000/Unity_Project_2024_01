using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance {  get; private set; }         //static�� ����ؼ� Instance ��� 
    private void Awake()
    {
        if(Instance == null)                    //Instance�� Null ���� ��쿡
        {
            Instance = this;                    //this�� �ڽ��� class�� return �Ѵ�. 
            DontDestroyOnLoad(gameObject);      //MonoBehaviour ������ ���� GameObject�� �ҽ��� �ְ� �ı� ���� �ʰ� �ϱ� ���ؼ��� 
                                                //DontDestoryOnLoad �Լ��� ����Ͽ� ������Ʈ�� �ı� ���� �ʰ� �Ѵ�. 
        }
        else
        {
            Destroy(gameObject);                //���� ���� �̱��� Ŭ������ �ν��Ͻ� �Ǿ������� �ش� ������Ʈ�� �ı� �Ѵ�. 
        }
    }
    public int playerScore = 0;
    public void AddScore(int amount)
    {
        playerScore += amount;
    }
}
